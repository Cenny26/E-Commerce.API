using FluentValidation;

namespace ECommerce.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithName("Name and Surname");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithName("E-mail Address");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithName("Password");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(x => x.Password)
                .WithName("Password Confirmation").WithMessage("The entered passwords do not match each other!");
        }
    }
}
