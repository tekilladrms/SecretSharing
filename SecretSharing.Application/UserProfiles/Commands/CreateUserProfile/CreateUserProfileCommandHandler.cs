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
    internal class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = UserProfile.Create();
            var result = await _unitOfWork.UserProfiles.AddAsync(userProfile);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }

    }
}
