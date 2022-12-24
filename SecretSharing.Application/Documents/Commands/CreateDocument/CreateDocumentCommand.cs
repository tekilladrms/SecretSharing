using MediatR;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Documents.Commands.CreateDocument
{
    public sealed record CreateDocumentCommand(DocumentDto DocumentDto, Guid UserProfileId) : IRequest<DocumentDto>;
    
}
