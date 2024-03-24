using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }
        public Category(int parentId, string name, int priority)
        {
            ParentId = parentId;
            Name = name;
            Priority = priority;
        }

        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
