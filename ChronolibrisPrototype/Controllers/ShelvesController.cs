using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelvesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelvesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserShelves(long userId)
        {
            var result = await _mediator.Send(new GetUserShelvesQuery(userId));
            return Ok(result);
        }
        [HttpGet("{shelfId}/books")]
        public async Task<IActionResult> GetShelfBooks(long shelfId, int page = 1, int pageSize = 20)
        {
            var result = await _mediator.Send(
                new GetShelfBooksQuery(shelfId, page, pageSize));

            return Ok(result);
        }
        [HttpPost("{shelfId}/books/{bookId}")]
        public async Task<IActionResult> AddBook(long shelfId, long bookId)
        {
            await _mediator.Send(new AddBookToShelfCommand(shelfId, bookId));
            return Ok();
        }

        [HttpDelete("{shelfId}/books/{bookId}")]
        public async Task<IActionResult> RemoveBook(long shelfId, long bookId)
        {
            await _mediator.Send(new RemoveBookFromShelfCommand(shelfId, bookId));
            return Ok();
        }

    }
}
