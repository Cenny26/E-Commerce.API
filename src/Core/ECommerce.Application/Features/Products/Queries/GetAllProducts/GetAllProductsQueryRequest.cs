using ECommerce.Application.Interfaces.RedisCache;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllProducts";
        #region cache time
        //Reducing the cache time to 10 minutes is only valid for the current request. Because this method is expected to be sent to this method by everyone (when the project is up and running) in a short period of time. As a result, it is necessary to keep the cache time to a minimum so that the changes of my commands are not lost for a long time while the project is running.
        #endregion
        public double CacheTime => 10;
    }
}
