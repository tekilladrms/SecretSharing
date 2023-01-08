using FluentValidation;
using SecretSharing.Domain.DomainRulesValidation;

namespace SecretSharing.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentFromFileCommandValidator : AbstractValidator<CreateDocumentFromFileCommand>
    {
        public CreateDocumentFromFileCommandValidator()
        {
            RuleFor(createFromFileCommand => createFromFileCommand.UserId)
                .NotNull()
                .NotEmpty()
                .Must(RulesForGuid.IsGuid).WithMessage("UserId should be guid");


        }
    }
}
