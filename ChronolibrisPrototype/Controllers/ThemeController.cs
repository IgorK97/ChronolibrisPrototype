// File: ChronolibrisPrototype.Controllers.ThemesController.cs
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThemesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получает список всех тем верхнего уровня
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ThemeDto>))]
        public async Task<ActionResult<IEnumerable<ThemeDto>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllThemesQuery(null);
            var themes = await _mediator.Send(query, cancellationToken);
            return Ok(themes);
        }

        /// <summary>
        /// Получает список дочерних тем для указанной родительской темы
        /// </summary>
        [HttpGet("parent/{parentThemeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ThemeDto>))]
        public async Task<ActionResult<IEnumerable<ThemeDto>>> GetByParentId(long parentThemeId, CancellationToken cancellationToken)
        {
            var query = new GetAllThemesQuery(parentThemeId);
            var themes = await _mediator.Send(query, cancellationToken);
            return Ok(themes);
        }

        /// <summary>
        /// Получает тему по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThemeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ThemeDto>> GetById(long id, CancellationToken cancellationToken)
        {
            var query = new GetThemeByIdQuery(id);
            var theme = await _mediator.Send(query, cancellationToken);

            if (theme == null)
                return NotFound(new { message = $"Тема с ID {id} не найдена" });

            return Ok(theme);
        }

        /// <summary>
        /// Создает новую запись темы
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<long>> Create([FromBody] CreateThemeRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Некорректные данные запроса", errors = ModelState });

            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(new { message = "Название темы обязательно" });

            try
            {
                var command = new CreateThemeCommand(request.Name, request.ParentThemeId);
                var id = await _mediator.Send(command, cancellationToken);
                return CreatedAtAction(nameof(GetById), new { id = id }, id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Обновляет существующую запись темы
        /// </summary>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(long id, [FromBody] UpdateThemeRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Некорректные данные запроса", errors = ModelState });

            if (id != request.Id)
                return BadRequest(new { message = "ID в пути и теле запроса не совпадают" });

            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(new { message = "Название темы обязательно" });

            try
            {
                var command = new UpdateThemeCommand(id, request.Name, request.ParentThemeId);
                await _mediator.Send(command, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Тема с ID {id} не найдена" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Удаляет запись темы
        /// </summary>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteThemeCommand(id);
                await _mediator.Send(command, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Тема с ID {id} не найдена" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}