using ECommerce.Application.DTOs.Brand;
using ECommerce.Application.DTOs.Category;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Products.Queries.GetProductByGuid
{
    public class GetProductByGuidQueryHandler : IRequestHandler<GetProductByGuidQueryRequest, GetProductByGuidQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules _productRules;
        public GetProductByGuidQueryHandler(IUnitOfWork unitOfWork, ProductRules productRules)
        {
            _unitOfWork = unitOfWork;
            _productRules = productRules;
        }

        public async Task<GetProductByGuidQueryResponse> Handle(GetProductByGuidQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(predicate: x => x.Id == request.Id && !x.IsDeleted, include: x => x.Include(b => b.Brand).Include(p => p.ProductCategories).ThenInclude(pc => pc.Category));

            await _productRules.EnsureProductExists(product, request.Id);

            var categoryNames = product.ProductCategories.Select(pc => pc.Category.Name).ToList();

            var response = new GetProductByGuidQueryResponse()
            {
                Title = product.Title,
                Description = product.Description,
                Brand = new BrandDto { Name = product.Brand.Name },
                Price = product.Price - (product.Price * product.Discount / 100),
                Discount = product.Discount,
                Categories = new CategoryDto { Name = string.Join(", ", categoryNames) }
            };

            return response;
        }
    }
}
