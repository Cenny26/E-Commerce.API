using ECommerce.Application.Bases;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        public DeleteProductCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IHttpContextAccessor _httpContextAccessor, ProductRules productRules) : base(_mapper, _unitOfWork, _httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            await _productRules.EnsureProductExists(product, request.Id);

            product.IsDeleted = true;

            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
