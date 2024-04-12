using ECommerce.Application.Bases;
using ECommerce.Application.Features.Auth.Rules;
using ECommerce.Application.Interfaces.AutoMappers;
using ECommerce.Application.Interfaces.Tokens;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerce.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly AuthRules _authRules;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public RefreshTokenCommandHandler(AuthRules authRules, UserManager<User> userManager, ITokenService tokenService, IMapper _mapper, IUnitOfWork _unitOfWork, IHttpContextAccessor _httpContextAccessor) : base(_mapper, _unitOfWork, _httpContextAccessor)
        {
            _authRules = authRules;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await _userManager.FindByEmailAsync(email);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            await _authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user, roles);
            string newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new RefreshTokenCommandResponse()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }
    }
}
