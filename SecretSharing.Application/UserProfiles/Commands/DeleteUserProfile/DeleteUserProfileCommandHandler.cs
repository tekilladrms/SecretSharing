using MediatR;
using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Commands.DeleteUserProfile
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _unitOfWork.UserProfiles.GetByIdAsync(request.UserProfileId);

            if (profile is null) throw new NotFoundDomainException($"User Profile with id = {request.UserProfileId} was not found");

            _unitOfWork.UserProfiles.Delete(request.UserProfileId);

            return Unit.Value;
        }
    }
}
