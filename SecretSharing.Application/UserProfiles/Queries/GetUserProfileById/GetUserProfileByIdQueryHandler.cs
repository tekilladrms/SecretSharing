using AutoMapper;
using Dapper;
using MediatR;
using SecretSharing.Application.Abstractions;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Exceptions;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Queries.GetUserProfileById
{
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _connectionFactory;

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

            if (userProfile is null) throw new NotFoundDomainException($"User profile with Id = {request.UserProfileId} was not found");

            return _mapper.Map<UserProfileDto>(userProfile);

        }
    }
}
