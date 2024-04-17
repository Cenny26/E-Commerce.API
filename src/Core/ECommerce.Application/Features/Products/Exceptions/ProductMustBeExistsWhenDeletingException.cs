using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class ProductMustBeExistsWhenDeletingException : BaseExceptions
    {
        public ProductMustBeExistsWhenDeletingException(int id) : base($"The product with the ID: {id} could not be found. Please make sure you've entered the correct ID.")
        {
        }
    }
}
