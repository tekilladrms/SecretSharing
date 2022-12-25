using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Application.Users.Commands.Logout
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
