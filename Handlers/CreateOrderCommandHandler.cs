using FluentValidation;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
{
    // public static async Task<Order> Handle(CreateOrderCommand command, AppDbContext context)
    // {
    //     var order = new Order
    //     {
    //         FirstName = command.FirstName,
    //         LastName = command.LastName,
    //         Status = command.Status,
    //         CreatedAt = DateTime.UtcNow,
    //         TotalCost = command.TotalCost
    //     };

    //     await context.Orders.AddAsync(order);
    //     await context.SaveChangesAsync();

    //     return order;
    // }

    private readonly AppDbContext _context;
    private readonly IValidator<CreateOrderCommand> _validator;

    public CreateOrderCommandHandler(AppDbContext context, IValidator<CreateOrderCommand> validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<OrderDto> HandleAsync(CreateOrderCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var order = new Order
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Status = command.Status,
            CreatedAt = DateTime.UtcNow,
            TotalCost = command.TotalCost
        };

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        return new OrderDto
        {
            Id = order.Id,
            FirstName = order.FirstName,
            LastName = order.LastName,
            Status = order.Status,
            CreatedAt = order.CreatedAt,
            TotalCost = order.TotalCost
        };
    }
}