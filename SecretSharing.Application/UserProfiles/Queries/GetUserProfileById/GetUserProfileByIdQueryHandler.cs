using AutoMapper;
using Dapper;
using MediatR;
using SecretSharing.Application.Abstractions;
using SecretSharing.Application.DTO;
using SecretSharing.Application.UserProfiles.Commands.CreateUserProfile;
using SecretSharing.Domain.Entities;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Queries.GetUserProfileById
{
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly IMediator _mediator;

        public GetUserProfileByIdQueryHandler(IMapper mapper, ISqlConnectionFactory sqlConnectionFactory)
        {
            _mapper = mapper;
            _connectionFactory = sqlConnectionFactory;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();

            UserProfile userProfile = await sqlConnection.QueryFirstOrDefaultAsync<UserProfile>(
                @"SELECT * FROM UserProfiles WHERE Id = @UserProfileId",
                new { request.UserProfileId });

            if (userProfile is null)
            {
                return await _mediator.Send(new CreateUserProfileCommand());
            }

            return _mapper.Map<UserProfileDto>(userProfile);

        }
    }
}
