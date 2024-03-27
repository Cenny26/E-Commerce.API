using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
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
        }
    }
}
