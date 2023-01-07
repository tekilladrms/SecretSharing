using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.Account.Commands.RegisterUser;
using SecretSharing.Application.Account.Queries.Login;
using SecretSharing.Application.Account.Queries.Logout;
using SecretSharing.Application.DTO;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/users/")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserDTO>> RegisterAsync([Required] string email, [Required] string password, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new RegisterUserCommand(email, password), 
                cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([Required] string email, [Required] string password, CancellationToken cancellationToken)
        {
            var resultToken = await _mediator.Send(
                new LoginQuery(email, password), 
                cancellationToken);
            return Ok(resultToken);
        }


        [HttpPost]
        [Route("logout")]
        public async Task<ActionResult> Logout(LogoutCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}
