using Microsoft.EntityFrameworkCore;
public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly ReadDbContext _context;

    // public static async Task<Order?> Handle(GetOrderByIdQuery query, ReadDbContext context)
    // => await context.Orders.FirstOrDefaultAsync(order => order.Id == query.OrderId);

    public GetOrderByIdQueryHandler(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<OrderDto?> HandleAsync(GetOrderByIdQuery query)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(order => order.Id == query.OrderId);

        if (order == null)
        {
            return null;
        }

        return new OrderDto
        {
            Id = order.Id,
            FirstName = order.FirstName,
            LastName = order.LastName,
            CreatedAt = order.CreatedAt,
            TotalCost = order.TotalCost
        };
    }
}