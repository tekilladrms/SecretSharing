using MediatR;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Queries.GetDocumentsByUserId
{
    internal class GetDocumentsByUserIdQueryHandler : IRequestHandler<GetDocumentsByUserIdQuery, IReadOnlyCollection<DocumentDto>>
    {
        public Task<IReadOnlyCollection<DocumentDto>> Handle(GetDocumentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
