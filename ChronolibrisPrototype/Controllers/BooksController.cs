using Chronolibris.Application.Queries;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{bookId}/read")]
        public async Task<ActionResult> GetBook(long bookId)
        {
            var result = await _mediator.Send(new GetBookFileQuery(bookId));
            //if (result != null)
            //    return File(result.FileBytes, result.ContentType, result.FileName);
            //return NotFound();
            if (result == null) //null pochemu-to :-/
                return NotFound();

            return new FileStreamResult(result.Stream, result.ContentType)
            {
                FileDownloadName = result.FileName,
            };
        }

        [HttpGet("{bookId}/info")]
        public async Task<ActionResult> GetBookMetadata(long bookId, long userId)
        {

            var metadata = await _mediator.Send(new GetBookMetadataQuery(bookId, userId));
            if(metadata != null)
                return Ok(metadata);
            return NotFound();
        }

        [HttpPost("{bookId}/progress")]
        public async Task<ActionResult> UpdateReadingProgress(UpdateReadingProgressCommand request)
        {
            var metadata = await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("readbooks")]
        public async Task<IActionResult> GetReadBooks(long userId, long? lastId, int limit=20)
        {

            var result = await _mediator.Send(new GetReadBooksQuery(userId, lastId, limit));
            return Ok(result);
        }
    }
}
