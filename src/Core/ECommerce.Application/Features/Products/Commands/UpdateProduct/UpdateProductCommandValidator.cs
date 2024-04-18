using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => int.TryParse(id.ToString(), out int parsedId) && parsedId > 0)
                .WithMessage("Identity must be a positive integer.")
                .WithName("Identity");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Title");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Description");

            RuleFor(x => x.BrandId)
                .Must(id => int.TryParse(id.ToString(), out int parsedId) && parsedId > 0)
                .WithMessage("Brand's identity must be a positive integer.")
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
                .Must(categories => categories.All(id => int.TryParse(id.ToString(), out int parsedId) && parsedId > 0))
                .WithMessage("Categories' identity must be a positive integer.")
                .WithName("Categories' identity");
        }
    }
}
