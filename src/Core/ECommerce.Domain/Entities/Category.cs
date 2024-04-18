using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category() { }
        public Category(Guid parentId, string name, int priority)
        {
            ParentId = parentId;
            Name = name;
            Priority = priority;
        }

        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
