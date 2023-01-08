using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SecretSharing.Application.Documents.Commands.CreateDocument
{
    public sealed record CreateDocumentFromFileCommand(IFormFile File, [Required]string UserId) : IRequest<string>;
    
}
