using ECommerce.Application.Bases;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Exceptions;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task ProductDataItemsMustNotBeSame(IList<Product> products, CreateProductCommandRequest request)
        {
            if (products.Any(x =>
                x.Title == request.Title &&
                x.Description == request.Description &&
                x.Price == request.Price &&
                x.Discount == request.Discount &&
                x.BrandId == request.BrandId &&
                x.ProductCategories.All(pc => request.CategoryIds.Contains(pc.CategoryId))
            ))
                throw new ProductDataItemsMustNotBeSameException();

            return Task.CompletedTask;
        }

        public Task ProductPriceMustNotBeInvalid(decimal price, decimal discount)
        {
            decimal discountedPrice = price - (price * discount / 100);
            if (discountedPrice < 0)
                throw new ProductPriceMustNotBeInvalidException();

            return Task.CompletedTask;
        }

        public async Task EnsureBrandExists(int brandId)
        {
            var brand = await _unitOfWork.GetReadRepository<Brand>().GetAsync(x => x.Id == brandId);
            if (brand is null)
                throw new EnsureBrandExistsException(brandId);

            await Task.CompletedTask;
        }

        public async Task EnsureCategoriesExist(IList<int> categoryIds)
        {
            List<int> notFoundCategoryIds = new List<int>();

            foreach (var categoryId in categoryIds)
            {
                var category = await _unitOfWork.GetReadRepository<Category>().GetAsync(x => x.Id == categoryId);
                if (category is null)
                    notFoundCategoryIds.Add(categoryId);
            }

            if (notFoundCategoryIds.Any())
                throw new EnsureCategoryExistsException(notFoundCategoryIds);

            await Task.CompletedTask;
        }

        public Task ProductMustBeExistsWhenDeleting(Product product, int id)
        {
            if (product is null)
                throw new ProductMustBeExistsWhenDeletingException(id);

            return Task.CompletedTask;
        }

        public Task ProductMustBeExistsWhenUpdating(Product product, int id)
        {
            if (product is null)
                throw new ProductMustBeExistsWhenUpdatingException(id);

            return Task.CompletedTask;
        }
    }
}
