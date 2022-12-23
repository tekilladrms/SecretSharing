using MediatR;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Commands.UpdateDocument
{
    public sealed record UpdateDocumentCommand(DocumentDto DocumentDto) : IRequest<DocumentDto>;
}
