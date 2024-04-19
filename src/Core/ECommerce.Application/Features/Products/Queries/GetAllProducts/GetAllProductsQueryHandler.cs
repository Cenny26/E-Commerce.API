using ECommerce.Application.DTOs.Brand;
using ECommerce.Application.DTOs.Category;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(predicate: x => !x.IsDeleted, include: x => x.Include(b => b.Brand).Include(p => p.ProductCategories).ThenInclude(pc => pc.Category));

            var responseList = new List<GetAllProductsQueryResponse>();

            foreach (var product in products)
            {
                var response = new GetAllProductsQueryResponse
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Brand = new BrandDto { Name = product.Brand.Name },
                    Price = product.Price - (product.Price * product.Discount / 100),
                    Discount = product.Discount,
                };

                var categoryNames = product.ProductCategories.Select(pc => pc.Category.Name).ToList();
                response.Categories = new CategoryDto { Name = string.Join(", ", categoryNames) };

                responseList.Add(response);
            }

            return responseList;
        }
    }
}
