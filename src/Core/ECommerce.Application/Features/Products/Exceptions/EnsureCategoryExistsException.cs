using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class EnsureCategoryExistsException : BaseExceptions
    {
        public EnsureCategoryExistsException(IList<Guid> categoryIds) : base($"The specified category identity(ies): {string.Join(", ", categoryIds)} does/do not exist!")
        {
        }
    }
}
