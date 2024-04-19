using MediatR;
using System.ComponentModel;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [DefaultValue("{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}")]
        public Guid BrandId { get; set; }
        [DefaultValue("You must enter the identity of the category(s) in array format.")]
        public IList<Guid> CategoryIds { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
