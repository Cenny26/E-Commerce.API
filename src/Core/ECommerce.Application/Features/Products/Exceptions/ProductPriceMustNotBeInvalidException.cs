using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class ProductPriceMustNotBeInvalidException : BaseExceptions
    {
        public ProductPriceMustNotBeInvalidException() : base("Discounted price cannot be negative!")
        {
        }
    }
}
