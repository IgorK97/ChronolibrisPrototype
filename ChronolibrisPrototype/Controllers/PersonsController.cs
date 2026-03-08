using Chronolibris.Application.Handlers;
using Chronolibris.Application.Models;
using ChronolibrisPrototype.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Получает список всех персон
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllPersonsQuery();
        var persons = await _mediator.Send(query, cancellationToken);
        return Ok(persons);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
    {
        byte[]? imageData = null;
        if (!string.IsNullOrEmpty(request.ImageBase64))
        {
            // Убираем префикс "data:image/jpeg;base64,", если фронтенд его прислал
            var base64Data = request.ImageBase64.Contains(",")
                ? request.ImageBase64.Split(',')[1]
                : request.ImageBase64;

            imageData = Convert.FromBase64String(base64Data);
        }

        var command = new CreatePersonCommand(
            request.Name,
            request.Description,
            imageData,
            request.FileName
        );

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id, CancellationToken token)
    {
        // Пример получения через твой репозиторий
        // В реальном проекте здесь лучше вызвать Query через MediatR
        var person = await _mediator.Send(new GetPersonByIdQuery(id));
        return person != null ? Ok(person) : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdatePersonRequest request)
    {
        byte[]? imageData = null;
        if (!string.IsNullOrEmpty(request.ImageBase64))
        {
            var base64Data = request.ImageBase64.Contains(",")
                ? request.ImageBase64.Split(',')[1]
                : request.ImageBase64;
            imageData = Convert.FromBase64String(base64Data);
        }

        var command = new UpdatePersonCommand(
            id,
            request.Name,
            request.Description,
            imageData,
            request.FileName
        );

        try
        {
            await _mediator.Send(command);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}