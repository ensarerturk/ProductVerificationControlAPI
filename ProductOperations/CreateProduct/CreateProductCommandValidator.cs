using FluentValidation;

namespace ProductManage.ProductOperations.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductModel>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Genre)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Genre cannot be empty.");
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(50).WithMessage("Name cannot be more than 50.");
        RuleFor(command => command.Price)
            .NotEmpty().WithMessage("Price cannot be empty.")
            .GreaterThan(0).WithMessage("Name cannot be less than 0.");
    }
}