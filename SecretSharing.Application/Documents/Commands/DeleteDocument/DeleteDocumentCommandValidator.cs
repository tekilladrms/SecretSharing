using FluentValidation;
using SecretSharing.Domain.DomainRulesValidation;

namespace SecretSharing.Application.Documents.Commands.DeleteDocument
{
    public class DeleteDocumentCommandValidator : AbstractValidator<DeleteDocumentCommand>
    {
        public DeleteDocumentCommandValidator()
        {
            RuleFor(deleteDocumentCommand => deleteDocumentCommand.UserId)
                .NotNull()
                .Must(RulesForGuid.IsGuid).WithMessage("UserId should be guid");

            RuleFor(deleteDocumentCommand => deleteDocumentCommand.FileName)
                .NotEmpty()
                .NotNull().WithMessage("FileName should be filled");
        }
    }
}
