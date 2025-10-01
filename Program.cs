using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BaseConnection")));
builder.Services.AddScoped<ICommandHandler<CreateOrderCommand, OrderDto>, CreateOrderCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetOrderByIdQuery, OrderDto>, GetOrderByIdQueryHandler>();

var app = builder.Build();


app.MapPost("/api/order", async (ICommandHandler<CreateOrderCommand, OrderDto> commandHandler, CreateOrderCommand command) =>
{
    // await context.Orders.AddAsync(order);
    // await context.SaveChangesAsync();
    var createdOrder = await commandHandler.HandleAsync(command);
    if (createdOrder == null)
    {
        return Results.BadRequest("Could not create order");
    }
    return Results.Created($"/order/{createdOrder.Id}", createdOrder);
});

app.MapGet("/api/order/{id}", async (IQueryHandler<GetOrderByIdQuery, OrderDto> queryHandler, int id) =>
{
    // var order = await context.Orders.FirstOrDefaultAsync(order => order.Id == id);
    var order = await queryHandler.HandleAsync(new GetOrderByIdQuery(id));
    return order != null ? Results.Ok(order) : Results.NotFound();
});

app.Run();
