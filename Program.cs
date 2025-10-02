using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BaseConnection")));
builder.Services.AddDbContext<ReadDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ReadDbConnection")));
builder.Services.AddDbContext<WriteDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("WriteDbConnection")));

builder.Services.AddScoped<ICommandHandler<CreateOrderCommand, OrderDto>, CreateOrderCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetOrderByIdQuery, OrderDto>, GetOrderByIdQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetOrderSummariesQuery, List<OrderSummaryDto>>, GetOrderSummariesQueryHandler>();
builder.Services.AddScoped<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
builder.Services.AddSingleton<IEventPublisher, InProcessEventPublisher>();
builder.Services.AddScoped<IEventHandler<OrderCreatedEvent>, OrderCreatedProjectionHandler>();

var app = builder.Build();


app.MapPost("/api/order", async (ICommandHandler<CreateOrderCommand, OrderDto> commandHandler, CreateOrderCommand command) =>
{
    // await context.Orders.AddAsync(order);
    // await context.SaveChangesAsync();
    try
    {
        var createdOrder = await commandHandler.HandleAsync(command);
        if (createdOrder == null)
        {
            return Results.BadRequest("Could not create order");
        }
        return Results.Created($"/order/{createdOrder.Id}", createdOrder);
    }
    catch (ValidationException ex)
    {
        var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
        return Results.BadRequest(errors);
    }
});

app.MapGet("/api/order/{id}", async (IQueryHandler<GetOrderByIdQuery, OrderDto> queryHandler, int id) =>
{
    // var order = await context.Orders.FirstOrDefaultAsync(order => order.Id == id);
    var order = await queryHandler.HandleAsync(new GetOrderByIdQuery(id));
    return order != null ? Results.Ok(order) : Results.NotFound();
});

app.MapGet("/api/orders", async (IQueryHandler<GetOrderSummariesQuery, List<OrderSummaryDto>> handler) =>
{ 
    return Results.Ok(await handler.HandleAsync(new GetOrderSummariesQuery()));    
});

app.Run();
