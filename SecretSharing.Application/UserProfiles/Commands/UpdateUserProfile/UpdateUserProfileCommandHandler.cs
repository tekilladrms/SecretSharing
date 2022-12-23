using AutoMapper;
using MediatR;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Repositories;
using SecretSharing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfileDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdateUserProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _unitOfWork.UserProfiles.GetByIdAsync(request.UserProfileDto.Id);

            if (profile is null) throw new NotFoundDomainException($"User profile with Id = {request.UserProfileDto.Id} was not found");

            if (profile.FirstName.Value != request.UserProfileDto.FirstName) profile.ChangeFirstName(request.UserProfileDto.FirstName);

            if (profile.LastName.Value != request.UserProfileDto.LastName) profile.ChangeFirstName(request.UserProfileDto.LastName);

            _unitOfWork.UserProfiles.Update(profile);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserProfileDto>(profile);
        }
    }
}
