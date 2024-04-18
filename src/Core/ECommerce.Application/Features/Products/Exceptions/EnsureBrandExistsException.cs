using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class EnsureBrandExistsException : BaseExceptions
    {
        public EnsureBrandExistsException(Guid brandId) : base($"The specified brand ID: {brandId} does not exist in the database!")
        {
        }
    }
}
