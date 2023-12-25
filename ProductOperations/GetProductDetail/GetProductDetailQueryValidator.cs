using FluentValidation;

namespace ProductManage.ProductOperations.GetProductDetail;

public class GetProductDetailQueryValidator : AbstractValidator<ProductDetailViewModel>
{
    public GetProductDetailQueryValidator()
    {
        RuleFor(query => query.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(50)
            .WithMessage("ProductId must be less than 50.");
        RuleFor(query => query.Price)
            .GreaterThan(0).WithMessage("Price must be more than 0");
    }
}