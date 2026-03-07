// File: ChronolibrisPrototype.Controllers.PublishersController.cs
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublishersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получает список всех издательств
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PublisherDto>))]
        public async Task<ActionResult<IEnumerable<PublisherDto>>> GetAllPublishers(CancellationToken cancellationToken)
        {
            var query = new GetAllPublishersQuery();
            var publishers = await _mediator.Send(query, cancellationToken);
            return Ok(publishers);
        }

        /// <summary>
        /// Получает издательство по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublisherDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublisherDto>> GetPublisherById(long id, CancellationToken cancellationToken)
        {
            var query = new GetPublisherByIdQuery(id);
            var publisher = await _mediator.Send(query, cancellationToken);

            if (publisher == null)
                return NotFound(new { message = $"Издательство с ID {id} не найдено" });

            return Ok(publisher);
        }

        /// <summary>
        /// Создает новую запись издательства
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<long>> CreatePublisher([FromBody] CreatePublisherRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Некорректные данные запроса", errors = ModelState });

            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(new { message = "Название издательства обязательно" });

            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest(new { message = "Описание издательства обязательно" });

            if (request.CountryId <= 0)
                return BadRequest(new { message = "ID страны должен быть указан" });

            var command = new CreatePublisherCommand(request.Name, request.Description, request.CountryId);
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetPublisherById), new { id = id }, id);
        }

        /// <summary>
        /// Обновляет существующую запись издательства
        /// </summary>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdatePublisher(long id, [FromBody] UpdatePublisherRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Некорректные данные запроса", errors = ModelState });

            if (id != request.Id)
                return BadRequest(new { message = "ID в пути и теле запроса не совпадают" });

            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(new { message = "Название издательства обязательно" });

            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest(new { message = "Описание издательства обязательно" });

            if (request.CountryId <= 0)
                return BadRequest(new { message = "ID страны должен быть указан" });

            var command = new UpdatePublisherCommand(request.Id, request.Name, request.Description, request.CountryId);
            var result = await _mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound(new { message = $"Издательство с ID {id} не найдено" });

            return NoContent();
        }

        /// <summary>
        /// Удаляет запись издательства
        /// </summary>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePublisher(long id, CancellationToken cancellationToken)
        {
            var command = new DeletePublisherCommand(id);
            var result = await _mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound(new { message = $"Издательство с ID {id} не найдено" });

            return NoContent();
        }
    }
}