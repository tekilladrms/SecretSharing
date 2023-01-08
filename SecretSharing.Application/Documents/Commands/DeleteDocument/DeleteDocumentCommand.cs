using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SecretSharing.Application.Documents.Commands.DeleteDocument
{
    public sealed record DeleteDocumentCommand([Required] string UserId, string FileName) : IRequest<Unit>;
    
}
