using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.DTO;
using SecretSharing.Application.UserProfiles.Commands.CreateUserProfile;
using SecretSharing.Application.Users;
using SecretSharing.Application.Users.Commands.Login;
using SecretSharing.Application.Users.Commands.RegisterUser;
using SecretSharing.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace SecretSharing.Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [HttpGet]
        public Task<ApplicationUser> Register()
        {
            throw new NotImplementedException();
        }

        // POST api/auth
        [HttpPost]
        public async Task<UserProfileDto> Register(string email, string password)
        {

            return await _mediator.Send(new RegisterUserCommand(email, password));
        }

        [HttpGet]
        public Task Login()
        {
            throw new NotImplementedException();
        }

        // POST api/auth/email
        [HttpPost]
        public async Task<UserProfileDto> Login(string email, string password)
        {
            return await _mediator.Send(new LoginCommand(email, password));
        }

        //public IActionResult Logout()
        //{

        //}
    }
}
