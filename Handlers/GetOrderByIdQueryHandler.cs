using Microsoft.EntityFrameworkCore;
public class GetOrderByIdQueryHandler
{
    public static async Task<Order?> Handle(GetOrderByIdQuery query, AppDbContext context)
    => await context.Orders.FirstOrDefaultAsync(order => order.Id == query.OrderId);
}