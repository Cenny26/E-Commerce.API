using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseExceptions
    {
        public EmailAddressShouldBeValidException() : base("There is no such email address!")
        {            
        }
    }
}
