using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserInfoDto>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginCommandHandler(
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserInfoDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            //var userProfile = await _unitOfWork.UserProfiles.GetByIdAsync(user.UserProfile.Guid);

            await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            

            return _mapper.Map<UserInfoDto>(user);
        }
    }
}
