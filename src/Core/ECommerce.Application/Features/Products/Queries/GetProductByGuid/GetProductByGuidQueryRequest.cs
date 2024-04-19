using MediatR;
using System.ComponentModel;

namespace ECommerce.Application.Features.Products.Queries.GetProductByGuid
{
    public class GetProductByGuidQueryRequest : IRequest<GetProductByGuidQueryResponse>
    {
        [DefaultValue("{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}")]
        public Guid Id { get; set; }
    }
}
