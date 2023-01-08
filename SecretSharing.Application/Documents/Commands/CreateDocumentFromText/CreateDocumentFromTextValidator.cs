using FluentValidation;
using SecretSharing.Domain.DomainRulesValidation;

namespace SecretSharing.Application.Documents.Commands.CreateDocumentFromText
{
    public class CreateDocumentFromTextValidator : AbstractValidator<CreateDocumentFromTextCommand>
    {
        public CreateDocumentFromTextValidator()
        {
            RuleFor(createDocumentFromTextCommand => createDocumentFromTextCommand.Title)
                .NotNull()
                .NotEmpty();

            RuleFor(createDocumentFromTextCommand => createDocumentFromTextCommand.UserId)
                .NotNull()
                .NotEmpty()
                .Must(RulesForGuid.IsGuid).WithMessage("UserId should be guid");

            RuleFor(createDocumentFromTextCommand => createDocumentFromTextCommand.Text)
                .NotEmpty()
                .NotNull();

        }
    }
}
