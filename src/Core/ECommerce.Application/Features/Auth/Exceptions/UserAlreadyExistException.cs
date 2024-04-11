using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseExceptions
    {
        public UserAlreadyExistException() : base("Such a user already exists!") 
        {
        }
    }
}
