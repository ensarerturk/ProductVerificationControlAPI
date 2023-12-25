using FluentValidation;

namespace ProductManage.ProductOperations.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(command => command.ProductId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("ProductId cannot be empty and must be greater than 0.");
    }
}