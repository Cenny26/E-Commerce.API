using FluentValidation;

namespace ECommerce.Application.Features.Products.Queries.GetProductByGuid
{
    public class GetProductByGuidQueryValidator : AbstractValidator<GetProductByGuidQueryRequest>
    {
        public GetProductByGuidQueryValidator()
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
