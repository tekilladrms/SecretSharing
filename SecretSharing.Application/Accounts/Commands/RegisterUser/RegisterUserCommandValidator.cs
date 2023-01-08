using FluentValidation;

namespace SecretSharing.Application.Accounts.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(registerUserCommand => registerUserCommand.email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(registerUserCommand => registerUserCommand.password)
                .NotNull()
                .NotEmpty()
                .Length(8, 20);
        }
    }
}
