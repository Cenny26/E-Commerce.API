using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class EnsureBrandExistsException : BaseExceptions
    {
        public EnsureBrandExistsException(Guid brandId) : base($"Product with ID: {brandId} does not exist!")
        {
        }
    }
}
