using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserProfileDto>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var userProfile = await _unitOfWork.UserProfiles.GetByIdAsync(user.UserProfileId);

            await _signInManager.SignInAsync(user, true);
            

            return _mapper.Map<UserProfileDto>(userProfile);
        }
    }
}
