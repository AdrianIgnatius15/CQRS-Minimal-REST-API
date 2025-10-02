using MediatR;

public class OrderCreatedProjectionHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly ReadDbContext _context;

    public OrderCreatedProjectionHandler(ReadDbContext context)
    {
        _context = context;
    }

    public async Task Handle(OrderCreatedEvent evt, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = evt.OrderId,
            FirstName = evt.FirstName,
            LastName = evt.LastName,
            Status = "Created",
            CreatedAt = DateTime.Now,
            TotalCost = evt.TotalCost
        };

        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}