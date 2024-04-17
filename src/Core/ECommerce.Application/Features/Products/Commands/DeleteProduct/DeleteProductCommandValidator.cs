using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => int.TryParse(id.ToString(), out int parsedId) && parsedId > 0).WithMessage("Id must be a positive integer.");
        }
    }
}
