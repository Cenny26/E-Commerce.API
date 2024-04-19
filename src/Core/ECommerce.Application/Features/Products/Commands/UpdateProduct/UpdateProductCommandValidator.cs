using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.")
                .Must(BeValidGuid).WithMessage("Invalid format for identity.")
                .WithName("Identity");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .WithName("Title");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .WithName("Description");

            RuleFor(x => x.BrandId)
                .NotEmpty().WithMessage("Brand's identity is required.")
                .Must(BeValidGuid).WithMessage("Invalid format for identity.")
                .WithName("Brand's identity");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than 0.")
                .WithName("Price");

            RuleFor(x => x.Discount)
                .NotEmpty().WithMessage("Discount is required.")
                .InclusiveBetween(0, 100).WithMessage("Discount must be between 0 and 100.")
                .WithName("Discount");

            RuleFor(x => x.CategoryIds)
                .NotEmpty().WithMessage("Categories' identity is required.")
                .Must(ids => ids.All(BeValidGuid)).WithMessage("Invalid format for identity.")
                .WithName("Categories' identity");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
