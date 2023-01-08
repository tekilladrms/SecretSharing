using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecretSharing.Application.Documents.Queries.GetAllDocumentsByUserId
{
    public sealed record GetAllDocumentsByUserIdQuery([Required] string UserId) : IRequest<IReadOnlyCollection<string>>;
}
