using MediatR;
using Microsoft.EntityFrameworkCore;
public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly ReadDbContext _context;

    // public static async Task<Order?> Handle(GetOrderByIdQuery query, ReadDbContext context)
    // => await context.Orders.FirstOrDefaultAsync(order => order.Id == query.OrderId);

    public GetOrderByIdQueryHandler(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(order => order.Id == query.OrderId, cancellationToken);

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