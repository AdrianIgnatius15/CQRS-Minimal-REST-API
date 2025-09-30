using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BaseConnection")));

var app = builder.Build();


app.MapPost("/api/order", async (AppDbContext context, CreateOrderCommand command) =>
{
    // await context.Orders.AddAsync(order);
    // await context.SaveChangesAsync();
    var createdOrder = await CreateOrderCommandHandler.Handle(command, context);
    if (createdOrder == null)
    {
        return Results.BadRequest("Could not create order");
    }
    return Results.Created($"/order/{createdOrder.Id}", createdOrder);
});

app.MapGet("/api/order/{id}", async (AppDbContext context, int id) =>
{
    // var order = await context.Orders.FirstOrDefaultAsync(order => order.Id == id);
    var order = await GetOrderByIdQueryHandler.Handle(new GetOrderByIdQuery(id), context);
    return order != null ? Results.Ok(order) : Results.NotFound();
});

app.Run();
