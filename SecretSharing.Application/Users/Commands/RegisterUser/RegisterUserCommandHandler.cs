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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(
            UserManager<ApplicationUser> userManger, 
            SignInManager<ApplicationUser> signInManager,
            IMediator mediator, 
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _userManager = userManger;
            _signInManager = signInManager;
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserProfileDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is not null)
            {
                throw new RestException($"User {request.Email} already exsist");
            }

            user.Email = request.Email;
            var userProfile = UserProfile.Create();

            await _unitOfWork.UserProfiles.AddAsync(userProfile);
            await _unitOfWork.SaveChangesAsync();

            
            user.UserProfileId = userProfile.Guid;

            var result = await _userManager.CreateAsync(user, request.Password);
            
            
            return _mapper.Map<UserProfileDto>(userProfile);
        }
    }
}
