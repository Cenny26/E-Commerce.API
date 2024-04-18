using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Title");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Description");

            RuleFor(x => x.BrandId)
                .NotEmpty()
                .WithName("Brand's identity");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Price");

            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100)
                .WithName("Discount");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .WithMessage("At least one category must be selected.")
                .WithName("Categories' identity");
        }
    }
}
