using ECommerce.Application.DTOs.Brand;
using ECommerce.Application.DTOs.Category;

namespace ECommerce.Application.Features.Products.Queries.GetProductByGuid
{
    public class GetProductByGuidQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BrandDto Brand { get; set; }
        public CategoryDto Categories { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
