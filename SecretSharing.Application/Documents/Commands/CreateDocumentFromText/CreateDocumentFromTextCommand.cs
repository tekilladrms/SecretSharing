using MediatR;

namespace SecretSharing.Application.Documents.Commands.CreateDocumentFromText
{
    public sealed record CreateDocumentFromTextCommand(string Text, string Title, string UserId) : IRequest<string>;
}
