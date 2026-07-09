using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Bovix_Platform.IAM.Domain.Model.Queries;
using Bovix_Platform.IAM.Domain.Services;
using Bovix_Platform.IAM.Interfaces.REST.Resources;
using Bovix_Platform.IAM.Interfaces.REST.Transform;
using Bovix_Platform.IAM.Infrastructure.Pipeline.Middleware.Attributes;


namespace Bovix_Platform.IAM.Interfaces.REST
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("User")]
    public class UserController(IUserCommandService commandService, IUserQueryService queryService) : ControllerBase
    {
        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
        {
            var command = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
            var (token, role) = await commandService.Handle(command);

            if (token is null) return BadRequest("User already exists");

            var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(token, role);

            return CreatedAtAction(nameof(SignUp), userResource);
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn([FromBody] SignInResource resource)
        {
            var command = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
            var (token, role) = await commandService.Handle(command);

            if (token is null) return BadRequest("Invalid credentials.");

            var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(token, role);

            return Ok(userResource);
        }

        [HttpGet("vets")]
        public async Task<IActionResult> GetVets()
        {
            var users = await queryService.Handle(new GetUsersByRoleQuery("VET"));
            var resources = users.Select(u => new VetResource(u.Id, u.Username, u.Email));
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await queryService.Handle(new GetUserByIdQuery(id));
            if (user is null) return NotFound();
            return Ok(new VetResource(user.Id, user.Username, user.Email));
        }
    }
}