using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class EnsureCategoryExistsException : BaseExceptions
    {
        public EnsureCategoryExistsException(IList<int> categoryIds) : base($"The specified category IDs: {string.Join(", ", categoryIds)} do not exist in the database!")
        {
        }
    }
}
