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

        [HttpGet("book.epub")]
        public async Task<ActionResult> GetBook()
        {
                var result = await _mediator.Send(new GetBookFileQuery());
                return File(result.FileBytes, result.ContentType, result.FileName);

        }
        //global exception handlers
        //служба доделать (в слое аппликэйшн)
        //модели в отдельные файлы классов
        //автоматическая генерация
        //посмотреть то, как регистрация еще может быть организована
        //всю логику вынести
        //феггинг фейс
        //Потоковая преедача
        //индекс.тс
        //Файл темплейтс, шаблоны
        //состояние зустанд можно в модели энтити сторе и использовать потом
        //nsvak
        //fsd models, entities, store (zustand states)

        [HttpGet("metadata")]
        public async Task<ActionResult> GetMetadata()
        {

            var metadata = await _mediator.Send(new GetBookMetadataQuery());
            return Ok(metadata);

        }
    }
}
