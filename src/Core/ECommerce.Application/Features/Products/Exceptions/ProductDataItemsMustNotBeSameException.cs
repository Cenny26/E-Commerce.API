using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class ProductDataItemsMustNotBeSameException : BaseExceptions
    {
        public ProductDataItemsMustNotBeSameException() : base("A product that includes all the information you entered is already in stock!")
        {
        }
    }
}
