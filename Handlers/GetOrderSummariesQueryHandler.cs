using Microsoft.EntityFrameworkCore;
public class GetOrderSummariesQueryHandler : IQueryHandler<GetOrderSummariesQuery, List<OrderSummaryDto>>
{
    public readonly AppDbContext _context;

    public GetOrderSummariesQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderSummaryDto>?> HandleAsync(GetOrderSummariesQuery query)
    {
        return await _context.Orders.Select(order => new OrderSummaryDto
        {
            OrderId = order.Id,
            CustomerName = order.FirstName + " " + order.LastName,
            Status = order.Status,
            TotalCost = order.TotalCost
        }).ToListAsync();
    }
}