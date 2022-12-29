using MediatR;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Queries.GetDocumentsByUserId
{
    public sealed record GetDocumentsByUserIdQuery(Guid ApplicationUserId) : IRequest<IReadOnlyCollection<DocumentDto>>;
}
