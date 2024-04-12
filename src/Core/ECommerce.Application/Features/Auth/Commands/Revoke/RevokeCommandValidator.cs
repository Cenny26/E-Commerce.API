using FluentValidation;

namespace ECommerce.Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandValidator : AbstractValidator<RevokeCommandRequest>
    {
        public RevokeCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
