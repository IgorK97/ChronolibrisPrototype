using Chronolibris.Application.DTOs;
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
        public async Task<IActionResult> GetReviews(long bookId)
        {
            var reviews = await _mediator.Send(new GetReviewsRequest(bookId));
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewRequest command)
        {
            
            var reviewId = await _mediator.Send(command);
            return Ok(reviewId);
        }

        [HttpPost("rate")]
        public async Task<IActionResult> RateReview(RateReviewRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
