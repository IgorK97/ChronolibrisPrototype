using System.Security.Claims;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SelectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSelections()
        {
            var result = await _mediator.Send(new GetSelectionsQuery());
            return Ok(result);
        }

        [HttpGet("{selectionId}/books")]
        [Authorize]
        public async Task<IActionResult> GetBooks(long selectionId, long? lastId, int limit = 20)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!long.TryParse(userIdClaim, out var userId))
                return Unauthorized();

            if (limit < 1) limit = 20;
            else if (limit > 100) limit = 100;

            var result = await _mediator.Send(
                new GetSelectionBooksQuery(selectionId, lastId, limit, userId));

            return Ok(result);
        }

    }
}
