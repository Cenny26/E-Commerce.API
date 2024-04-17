using ECommerce.Application.Bases;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        public CreateProductCommandHandler(ProductRules productRules, IMapper _mapper, IUnitOfWork _unitOfWork, IHttpContextAccessor _httpContextAccessor) : base(_mapper, _unitOfWork, _httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand).Include(p => p.ProductCategories));

            await _productRules.EnsureBrandExists(brandId: request.BrandId);
            await _productRules.EnsureCategoriesExist(categoryIds: request.CategoryIds);
            await _productRules.ProductDataItemsMustNotBeSame(products, request);
            await _productRules.ProductPriceMustNotBeInvalid(request.Price, request.Discount);

            Product product = new Product(request.Title, request.Description, request.Price, request.Discount, request.BrandId);

            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await _unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId,
                    });

                await _unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
