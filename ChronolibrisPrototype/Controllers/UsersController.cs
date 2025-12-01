using System.Security.Claims;
using Chronolibris.Application.Models;
using Chronolibris.Application.Queries;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult> Refresh(string refreshToken)
        {
            var result = await _mediator.Send(new RefreshTokenCommand(refreshToken));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                Email = User.FindFirstValue(ClaimTypes.Email),
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
        }
    }
}
