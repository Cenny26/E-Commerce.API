using ECommerce.Application.Bases;
using ECommerce.Application.Features.Auth.Rules;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthRules _authRules;
        public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IMapper _mapper, IUnitOfWork _unitOfWork, IHttpContextAccessor _httpContextAccessor) : base(_mapper, _unitOfWork, _httpContextAccessor)
        {
            _userManager = userManager;
            _authRules = authRules;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByEmailAsync(request.Email);

            await _authRules.EmailAddressShouldBeValid(user);

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
