using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
    {
        public RefreshTokenShouldNotBeExpiredException() : base("The session has expired. Please login again!")
        {            
        }
    }
}
