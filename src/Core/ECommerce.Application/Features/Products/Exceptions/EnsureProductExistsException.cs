using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class EnsureProductExistsException : BaseExceptions
    {
        public EnsureProductExistsException(Guid productId) : base($"Product with ID: {productId} does not exist!")
        {
        }
    }
}
