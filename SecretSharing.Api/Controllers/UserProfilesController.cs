using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretSharing.Application.DTO;
using SecretSharing.Application.UserProfiles.Commands.CreateUserProfile;
using SecretSharing.Application.UserProfiles.Commands.DeleteUserProfile;
using SecretSharing.Application.UserProfiles.Commands.UpdateUserProfile;
using SecretSharing.Application.UserProfiles.Queries.GetUserProfileById;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecretSharing.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/users
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var user = await _mediator.Send(new GetUserProfileByIdQuery(userId));

            if (user is null) return BadRequest();

            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var user = await _mediator.Send(new CreateUserProfileCommand());

            if (user is null) return BadRequest();

            return Created($"api/users/{user.Id}", user);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UserProfileDto userProfileDto)
        {
            var user = await _mediator.Send(new UpdateUserProfileCommand(userProfileDto));

            if (user is null) return BadRequest();

            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid userProfileId)
        {
            return Ok(await _mediator.Send(new DeleteUserProfileCommand(userProfileId)));
        }
    }
}
