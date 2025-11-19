using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookmarksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookmarkCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveBookmarkCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return NotFound(0);
            return Ok();
        }

        [HttpGet("{bookId}/user/{userId}")]
        public async Task<IActionResult> GetAll(long bookId, long userId)
        {
            var bookmarks = await _mediator.Send(new GetBookmarksQuery(bookId, userId));
            return Ok(bookmarks);
        }
    }
}
