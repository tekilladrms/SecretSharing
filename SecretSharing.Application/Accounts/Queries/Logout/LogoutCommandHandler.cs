using MediatR;
using Microsoft.AspNetCore.Identity;
using SecretSharing.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Accounts.Queries.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {

            await _signInManager.SignOutAsync();

            return Unit.Value;
        }
    }
}
