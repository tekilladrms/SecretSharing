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

namespace SecretSharing.Application.Documents.Queries.GetDocumentById
{
    internal class GetDocumentByIdqueryHandler : IRequestHandler<GetDocumentByIdQuery, DocumentDto>
    {
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetDocumentByIdqueryHandler(IMapper mapper, ISqlConnectionFactory connectionFactory)
        {
            _mapper = mapper;
            _connectionFactory = connectionFactory;
        }

        public async Task<DocumentDto> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();

            Document document = await sqlConnection.QueryFirstOrDefaultAsync<Document>(
                @"SELECT * FROM Documents WHERE Id = @DocumentId", new { request.DocumentId });

            if (document is null) throw new NotFoundDomainException($"Document with Id = {request.DocumentId} was not found");

            return _mapper.Map<DocumentDto>(document);
        }
    }
}
