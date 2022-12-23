using AutoMapper;
using Dapper;
using MediatR;
using SecretSharing.Application.Abstractions;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Queries.GetUsersByDocument
{
    internal class GetUsersByDocumentIdQueryHandler : IRequestHandler<GetUsersByDocumentIdQuery, IReadOnlyCollection<UserProfileDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetUsersByDocumentIdQueryHandler(IMapper mapper, ISqlConnectionFactory connectionFactory)
        {
            _mapper = mapper;
            _connectionFactory = connectionFactory;
        }

        public async Task<IReadOnlyCollection<UserProfileDto>> Handle(GetUsersByDocumentIdQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();

            var users = await sqlConnection.QueryAsync<UserInfoDto>(
                @"SELECT Guid, FirstName, LastName FROM UserProfiles 
                WHERE Guid IN (
                    SELECT DocumentName FROM Documents)");
            return _mapper.Map<IReadOnlyCollection<UserProfileDto>>(new List<UserProfile>());
        }
    }
}
