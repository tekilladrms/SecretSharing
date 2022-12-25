using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.DTO;
using SecretSharing.Application.UserProfiles.Commands.CreateUserProfile;
using SecretSharing.Application.Users.Commands.Login;
using SecretSharing.Application.Users.Commands.RegisterUser;
using SecretSharing.Persistence.Repositories;
using System.Threading.Tasks;

namespace SecretSharing.Api.Controllers
{

    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<UserProfileDto> Register(string email, string password)
        {

            return await _mediator.Send(new RegisterUserCommand(email, password));
        }

        public async Task<UserProfileDto> Login(string email, string password)
        {
            return await _mediator.Send(new LoginCommand(email, password));
        }

        public IActionResult Logout()
        {

        }
    }
}
