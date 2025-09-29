using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BaseConnection")));

var app = builder.Build();


app.MapPost("/api/order", async (AppDbContext context, Order order) =>
{
    await context.Orders.AddAsync(order);
    await context.SaveChangesAsync();
    return Results.Created($"/order/{order.Id}", order);
});

app.MapGet("/api/order/{id}", async (AppDbContext context, int id) =>
{
    var order = await context.Orders.FindAsync(id);
    return order != null ? Results.Ok(order) : Results.NotFound();
});

app.Run();
