using FluentValidation;

namespace MyProductApi.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product must be Name");

            RuleFor(x => x.Price).NotEqual(0).WithMessage("Product must be Price");
        }
    }
}
