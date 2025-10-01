using FluentValidation;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(c => c.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(c => c.Status).NotEmpty().WithMessage("Status is required.");
        RuleFor(c => c.TotalCost).GreaterThan(0).WithMessage("Total cost must be greater than zero.");
    }
}