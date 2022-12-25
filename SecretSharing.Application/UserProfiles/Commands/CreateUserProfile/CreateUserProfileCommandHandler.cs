using AutoMapper;
using MediatR;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfileDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = UserProfile.Create();
            var result = await _unitOfWork.UserProfiles.AddAsync(userProfile);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserProfileDto>(result);
        }

    }
}
