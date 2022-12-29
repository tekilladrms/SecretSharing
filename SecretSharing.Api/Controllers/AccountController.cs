using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.Users.Commands.Login;
using SecretSharing.Application.Users.Commands.RegisterUser;
using SecretSharing.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SecretSharing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IActionResult> Register()
        {
            throw new NotImplementedException();
        }

        // POST api/auth
        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {

            return Ok(await _mediator.Send(new RegisterUserCommand(email, password)));
        }

        [HttpGet]
        public Task Login()
        {
            throw new NotImplementedException();
        }

        // POST api/auth/email
        [HttpPost("{login}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            return Ok(await _mediator.Send(new LoginCommand(email, password)));
        }

        //public IActionResult Logout()
        //{

        //}
    }
}
