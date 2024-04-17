using ECommerce.Application.Interfaces.RedisCache;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllProducts";
        public double CacheTime => 60;
    }
}
