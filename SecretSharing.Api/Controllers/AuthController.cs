//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using SecretSharing.Application.Users;
//using SecretSharing.Application.Users.Commands.Login;
//using SecretSharing.Application.Users.Commands.RegisterUser;
//using System;
//using System.Threading.Tasks;

//namespace SecretSharing.Api.Controllers
//{
//    [ApiController]
//    [Route("api/auth")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IMediator _mediator;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public AuthController(IMediator mediator, UserManager<ApplicationUser> userManager)
//        {
//            //_userManager = userManager;
//            _mediator = mediator;
//        }

//        [HttpGet]
//        public Task<IActionResult> Register()
//        {
//            throw new NotImplementedException();
//        }

//        // POST api/auth
//        [HttpPost]
//        public async Task<IActionResult> Register(string email, string password)
//        {

//            return Ok( await _mediator.Send(new RegisterUserCommand(email, password)));
//        }

//        [HttpGet]
//        public Task Login()
//        {
//            throw new NotImplementedException();
//        }

//        // POST api/auth/email
//        [HttpPost]
//        public async Task<IActionResult> Login(string email, string password)
//        {
//            return Ok(await _mediator.Send(new LoginCommand(email, password)));
//        }

//        //public IActionResult Logout()
//        //{

//        //}
//    }
//}
