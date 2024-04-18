using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class ProductMustBeExistsWhenUpdatingException : BaseExceptions
    {
        public ProductMustBeExistsWhenUpdatingException(Guid id) : base($"The product with the ID: {id} could not be found. Please make sure you've entered the correct ID.")
        {
        }
    }
}
