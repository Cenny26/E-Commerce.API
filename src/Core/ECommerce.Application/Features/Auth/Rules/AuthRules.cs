using ECommerce.Application.Bases;
using ECommerce.Application.Features.Auth.Exceptions;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null)
                throw new UserAlreadyExistException();

            return Task.CompletedTask;
        }
    }
}
