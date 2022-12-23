using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Commands.DeleteDocument
{
    public sealed record DeleteDocumentCommand(Guid DocumentId) : IRequest<Unit>;
    
}
