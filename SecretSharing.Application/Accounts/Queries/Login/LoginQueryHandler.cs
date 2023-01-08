using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Rest;
using SecretSharing.Application.Abstractions;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Accounts.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, UserDTO>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public LoginQueryHandler(
            UserManager<ApplicationUser> userManager,
            IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<UserDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new RestException("email/password is wrong");
            }

            var userDTO = new UserDTO()
            {
                Email = user.Email,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Token = _jwtProvider.Generate(user)
            };
            return userDTO;
            
        }
    }
}
