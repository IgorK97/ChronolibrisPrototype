using Chronolibris.Application.Requests;
using MediatR;
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
        public async Task<IActionResult> GetBooks(long selectionId, long? lastId, int limit = 20)
        {
            if (limit < 1) limit = 20;
            else if (limit > 100) limit = 100;

            var result = await _mediator.Send(
                new GetSelectionBooksQuery(selectionId, lastId, limit));

            return Ok(result);
        }

    }
}
