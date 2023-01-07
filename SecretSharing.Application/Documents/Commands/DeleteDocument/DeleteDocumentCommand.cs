using MediatR;

namespace SecretSharing.Application.Documents.Commands.DeleteDocument
{
    public sealed record DeleteDocumentCommand(string UserId, string FileName) : IRequest<Unit>;
    
}
