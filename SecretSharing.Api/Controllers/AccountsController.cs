using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.Accounts.Commands.RegisterUser;
using SecretSharing.Application.Accounts.Queries.Login;
using SecretSharing.Application.Accounts.Queries.Logout;
using SecretSharing.Application.DTO;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSharing.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/users/")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserDTO>> RegisterAsync([FromBody]RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                request,
                cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginQuery request, CancellationToken cancellationToken)
        {
            var resultToken = await _mediator.Send(
                request,
                cancellationToken);
            return Ok(resultToken);
        }


        //[HttpPost]
        //[Route("logout")]
        //public async Task<ActionResult> Logout(LogoutCommand request, CancellationToken cancellationToken)
        //{
        //    return Ok(await _mediator.Send(request, cancellationToken));
        //}
    }
}
