using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithName("Identity");

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
                .WithMessage("Categories' identity must be a positive integer.")
                .WithName("Categories' identity");
        }
    }
}
