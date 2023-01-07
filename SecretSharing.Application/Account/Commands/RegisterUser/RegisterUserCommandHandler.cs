using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Rest;
using SecretSharing.Application.Abstractions;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Account.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDTO>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public RegisterUserCommandHandler(
            UserManager<ApplicationUser> userManger,
            IJwtProvider jwtProvider)
        {
            _userManager = userManger;
            _jwtProvider = jwtProvider;
        }

        public async Task<UserDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);

            if (user is not null)
            {
                throw new RestException($"User {request.email} already exsist");
            }
            
            user = new ApplicationUser();
            user.Id = Guid.NewGuid().ToString();
            user.Email = request.email;
            user.UserName = user.GetNameFromEmail(user.Email);
            
            var result = await _userManager.CreateAsync(user, request.password);
            
            if (!result.Succeeded)
            {
                throw new RestException("user was not created");
            }
            return new UserDTO
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = _jwtProvider.Generate(user),
                Id = user.Id.ToString()
            };
        }

    }
}
