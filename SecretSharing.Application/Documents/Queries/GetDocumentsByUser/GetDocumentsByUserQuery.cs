using MediatR;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Queries.GetDocumentsByUser
{
    public sealed record GetDocumentsByUserQuery(Guid UserId) : IRequest<IReadOnlyCollection<DocumentDto>>;
}
