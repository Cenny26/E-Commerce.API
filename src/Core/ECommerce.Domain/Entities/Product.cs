using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product() { }
        public Product(string title, string description, decimal price, decimal discount, Guid brandId)
        {
            Title = title;
            Description = description;
            Price = price;
            Discount = discount;
            BrandId = brandId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
