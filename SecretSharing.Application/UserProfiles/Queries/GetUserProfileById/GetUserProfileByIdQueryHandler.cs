using AutoMapper;
using Dapper;
using MediatR;
using SecretSharing.Application.Abstractions;
using SecretSharing.Application.DTO;
using SecretSharing.Application.UserProfiles.Commands.CreateUserProfile;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Repositories;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Queries.GetUserProfileById
{
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserProfileByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var userProfile = await _unitOfWork.UserProfiles.GetByIdWithDocumentsAsync(request.UserProfileId, cancellationToken);

            return _mapper.Map<UserProfileDto>(userProfile);

        }
    }
}
