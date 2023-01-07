using MediatR;
using System.Collections.Generic;

namespace SecretSharing.Application.Documents.Queries.GetAllDocumentsByUserId
{
    public sealed record GetAllDocumentsByUserIdQuery(string UserId) : IRequest<IReadOnlyCollection<string>>;
}
