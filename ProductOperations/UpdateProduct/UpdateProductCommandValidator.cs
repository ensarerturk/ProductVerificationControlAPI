using FluentValidation;

namespace ProductManage.ProductOperations.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(command => command.ProductId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("ProductId cannot be empty and must be greater than 0.");

        RuleFor(command => command.Model)
            .NotNull();
    }
}