using MediatR;
using Microsoft.AspNetCore.Http;

namespace SecretSharing.Application.Documents.Commands.CreateDocument
{
    public sealed record CreateDocumentFromFileCommand(IFormFile File, string UserId) : IRequest<string>;
    
}
