using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Account.Queries.Login
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
