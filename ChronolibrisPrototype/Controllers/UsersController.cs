using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Chronolibris.Application.Models;
using Chronolibris.Application.Queries;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YamlDotNet.Core.Tokens;

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
            if (!result.Success || string.IsNullOrEmpty(result.Token))
            {
                return Unauthorized(new { message = result.Message });
            }
            var token = result.Token;
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("token", token, cookieOptions);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserCommand request)
        {
            var result = await _mediator.Send(request);
            if(!result.Success || string.IsNullOrEmpty(result.Token))
            {
                return Unauthorized(new { message = result.Message });
            }
            var token = result.Token;
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("token", token, cookieOptions);
            return Ok();
        }

        [HttpPost("refresh")]
        public async Task<ActionResult> Refresh(string refreshToken)
        {
            var result = await _mediator.Send(new RefreshTokenCommand(refreshToken));
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !long.TryParse(userId, out long parsedUserId))
                return Unauthorized();

            //long parsedUserId = long.Parse(userId);
            try
            {
                var result = await _mediator.Send(new GetUserProfileQuery(parsedUserId));
                return result !=null ? Ok(result): NotFound();

            }
            catch (Exception ex) {
                return StatusCode(500, "Ошибка при получении профиля");
            }
        }

        [Authorize]
        [HttpPost("profile")]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileCommand request)
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (userId == null)
            //    return Unauthorized();

            //long parsedUserId = long.Parse(userId);

            //var command = new UpdateUserProfileCommand
            //{
            //    UserId = parsedUserId,
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    Email = request.Email
            //};

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand request) 
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (userId == null)
            //    return Unauthorized();

            //long parsedUserId = long.Parse(userId);

            //var command = new ChangePasswordCommand
            //{
            //    UserId = parsedUserId,
            //    CurrentPassword = request.CurrentPassword,
            //    NewPassword = request.NewPassword
            //};

            await _mediator.Send(request);

            return Ok(new { success = true, message = "Password changed successfully" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            //TODO:
            //var token = Request.Cookies["token"];
            //if (!string.IsNullOrEmpty(token))
            //{
            //    var handler = new JwtSecurityTokenHandler();
            //    var jwtToken = handler.ReadJwtToken(token);
            //    var jti = jwtToken.Id; // This gets the JTI claim
            //    var expiry = jwtToken.ValidTo;

            //    // 1. Add to PostgreSQL
            //    await _db.TokenBlacklist.AddAsync(new BlacklistedToken { Id = jti, Expiry = expiry });
            //    await _db.SaveChangesAsync();

            //    // 2. Add to IMemoryCache (for fast checking)
            //    _memoryCache.Set(jti, true, expiry - DateTime.UtcNow);
            //}

            //Response.Cookies.Delete("token", new CookieOptions { /* your options */ });
            //return Ok();


            Response.Cookies.Delete("token", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
            return Ok();
        }
    }
}

   
