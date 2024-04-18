using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class ProductCategory : IEntityBase
    {
        public ProductCategory() { }
        public ProductCategory(Guid productId, Guid categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }

        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
