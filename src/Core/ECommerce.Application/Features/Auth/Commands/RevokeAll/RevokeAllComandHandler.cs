using ECommerce.Application.Bases;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Auth.Commands.RevokeAll
{
    public class RevokeAllComandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest, Unit>
    {
        private readonly UserManager<User> _userManager;
        public RevokeAllComandHandler(UserManager<User> userManager, IMapper _mapper, IUnitOfWork _unitOfWork, IHttpContextAccessor _httpContextAccessor) : base(_mapper, _unitOfWork, _httpContextAccessor)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            List<User> users = await _userManager.Users.ToListAsync(cancellationToken);

            foreach (User user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }

            return Unit.Value;
        }
    }
}
