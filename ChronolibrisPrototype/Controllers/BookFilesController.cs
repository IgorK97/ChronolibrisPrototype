// File: ChronolibrisPrototype.Controllers.BookFilesController.cs
using Chronolibris.Application.Models;
using Chronolibris.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookFilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookFilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получает список всех файлов для книги
        /// </summary>
        [HttpGet("book/{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BookFileDto>))]
        public async Task<ActionResult<List<BookFileDto>>> GetBookFiles(long bookId, CancellationToken cancellationToken)
        {
            var query = new GetBookFilesQuery(bookId);
            var files = await _mediator.Send(query, cancellationToken);
            return Ok(files);
        }

        /// <summary>
        /// Получает файл книги по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookFileDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookFileDto>> GetBookFile(long id, CancellationToken cancellationToken)
        {
            var query = new GetBookFileQuery(id);
            var file = await _mediator.Send(query, cancellationToken);

            if (file == null)
                return NotFound(new { message = $"Файл с ID {id} не найден" });

            return Ok(file);
        }

        /// <summary>
        /// Скачивает файл книги
        /// </summary>
        [HttpGet("{id}/download")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DownloadBookFile(long id, CancellationToken cancellationToken)
        {
            var query = new GetBookFileStreamQuery(id);
            var stream = await _mediator.Send(query, cancellationToken);

            if (stream == null)
                return NotFound(new { message = $"Файл с ID {id} не найден" });

            return File(stream, "application/octet-stream", $"book_file_{id}");
        }

        /// <summary>
        /// Загружает новый файл для книги
        /// </summary>
        [Authorize]
        [HttpPost]
        [RequestSizeLimit(100 * 1024 * 1024)] // 100 MB
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<long>> UploadBookFile(
            [FromForm] long bookId,
            [FromForm] int formatId,
            [FromForm] bool isReadable,
            IFormFile file,
            CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "Файл не предоставлен" });

            if (!TryGetUserId(out var userId))
                return Unauthorized(new { message = "Пользователь не авторизован" });

            try
            {
                var command = new UploadBookFileCommand(bookId, formatId, isReadable, file.OpenReadStream(), file.FileName, file.Length,userId);
                var id = await _mediator.Send(command, cancellationToken);
                return CreatedAtAction(nameof(GetBookFile), new { id = id }, id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Обновляет (перезаписывает) файл книги
        /// </summary>
        [Authorize]
        [HttpPut("book/{bookId}/format/{formatId}")]
        [RequestSizeLimit(100 * 1024 * 1024)] // 100 MB
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBookFile(
            long bookId,
            int formatId,
            [FromForm] bool isReadable,
            IFormFile file,
            CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "Файл не предоставлен" });

            if (!TryGetUserId(out var userId))
                return Unauthorized(new { message = "Пользователь не авторизован" });

            try
            {
                var command = new UpdateBookFileCommand(bookId, formatId, isReadable, file.OpenReadStream(), file.FileName, file.Length, userId);
                var id = await _mediator.Send(command, cancellationToken);
                return Ok(new { id = id });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Файл не найден для книги {bookId} и формата {formatId}" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Удаляет файл книги
        /// </summary>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteBookFile(long id, CancellationToken cancellationToken)
        {
            if (!TryGetUserId(out var userId))
                return Unauthorized(new { message = "Пользователь не авторизован" });

            try
            {
                var command = new DeleteBookFileCommand(id, userId);
                await _mediator.Send(command, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Файл с ID {id} не найден" });
            }
        }

        private bool TryGetUserId(out long userId)
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            return long.TryParse(claim?.Value, out userId);
        }
    }
}