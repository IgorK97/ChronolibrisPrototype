using Chronolibris.Application.Queries;
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
            if (result == null)
                return NotFound();

            return new FileStreamResult(result.Stream, result.ContentType)
            {
                FileDownloadName = result.FileName,
            };
        }

        [HttpGet("{bookId}/info")]
        public async Task<ActionResult> GetBookMetadata(long bookId)
        {

            var metadata = await _mediator.Send(new GetBookMetadataQuery(bookId));
            if(metadata != null)
                return Ok(metadata);
            return NotFound();
        }
    }
}
