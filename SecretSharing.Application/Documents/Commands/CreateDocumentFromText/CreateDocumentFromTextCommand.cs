using MediatR;
using System.ComponentModel.DataAnnotations;

namespace SecretSharing.Application.Documents.Commands.CreateDocumentFromText
{
    public sealed record CreateDocumentFromTextCommand(string Text, string Title, [Required] string UserId) : IRequest<string>;
}
