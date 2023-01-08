using FluentValidation;

namespace SecretSharing.Application.Accounts.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(loginQuery => loginQuery.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(loginQuery => loginQuery.Password)
                .NotNull()
                .NotEmpty()
                .Length(8, 20);
        }
    }
}
