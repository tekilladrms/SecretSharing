using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Rest;
using SecretSharing.Application.DTO;
using SecretSharing.Application.UserProfiles.Commands.CreateUserProfile;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserProfileDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(
            UserManager<ApplicationUser> userManger, 
            SignInManager<ApplicationUser> signInManager,
            IMediator mediator, 
            IMapper mapper
            )
        {
            _userManager = userManger;
            _signInManager = signInManager;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is not null)
            {
                throw new RestException($"User {request.Email} already exsist");
            }

            user.Email = request.Email;
            user.UserProfile = _mapper.Map<UserProfile>(await _mediator.Send(new CreateUserProfileCommand()));

            await _userManager.CreateAsync(user, request.Password);

            return _mapper.Map<UserProfileDto>(UserProfile.Create());
        }
    }
}
