using MediatR;
using Microsoft.EntityFrameworkCore;
public class GetOrderSummariesQueryHandler : IRequestHandler<GetOrderSummariesQuery, List<OrderSummaryDto>>
{
    public readonly ReadDbContext _context;

    public GetOrderSummariesQueryHandler(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderSummaryDto>> Handle(GetOrderSummariesQuery query, CancellationToken cancellationToken)
    {
        return await _context.Orders.Select(order => new OrderSummaryDto
        {
            OrderId = order.Id,
            CustomerName = order.FirstName + " " + order.LastName,
            Status = order.Status,
            TotalCost = order.TotalCost
        })
        .AsNoTracking()
        .ToListAsync(cancellationToken);
    }
}