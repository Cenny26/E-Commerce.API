using ECommerce.Application.Bases;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        public UpdateProductCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IHttpContextAccessor _httpContextAccessor, ProductRules productRules) : base(_mapper, _unitOfWork, _httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            await _productRules.EnsureProductExists(product, request.Id);
            await _productRules.EnsureBrandExists(brandId: request.BrandId);
            await _productRules.EnsureCategoriesExist(categoryIds: request.CategoryIds);
            await _productRules.ProductPriceMustNotBeInvalid(request.Price, request.Discount);

            var map = _mapper.Map<Product, UpdateProductCommandRequest>(request);

            var productCategories = await _unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x => x.ProductId == product.Id);

            await _unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
                await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory()
                {
                    ProductId = product.Id,
                    CategoryId = categoryId
                });

            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
