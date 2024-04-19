using MediatR;
using System.ComponentModel;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<Unit>
    {
        [DefaultValue("{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}")]
        public Guid Id { get; set; }
    }
}
