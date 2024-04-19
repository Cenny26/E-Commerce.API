using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product identity cannot be empty.")
                .Must(BeValidGuid).WithMessage("Invalid format for identity.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
