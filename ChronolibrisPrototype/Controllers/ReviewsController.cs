using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetReviews(long bookId, long? lastId, int limit=20, long? userId=null)
        {
            if (limit < 1) limit = 20;
            else if (limit > 20) limit = 20;

            var reviews = await _mediator.Send(new GetReviewsQuery(bookId, lastId, limit, userId));
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            
            var reviewId = await _mediator.Send(command);
            return Ok(reviewId);
        }

        [HttpPost("rate")]
        public async Task<IActionResult> RateReview(RateReviewCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
