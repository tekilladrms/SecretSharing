using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Rest;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserInfoDto>
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

        public async Task<UserInfoDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is not null)
            {
                throw new RestException($"User {request.Email} already exsist");
            }

            user = new ApplicationUser();
            user.Email = request.Email;
            user.UserName = request.Email;
            
            
            var result = await _userManager.CreateAsync(user, request.Password);
            
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserInfoDto>(user);
        }

    }
}
