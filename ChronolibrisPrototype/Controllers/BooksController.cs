using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChronolibrisPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public BooksController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("book.epub")]
        public async Task<ActionResult> GetBook()
        {
            try
            {
                var booksFolder = Path.Combine(_environment.ContentRootPath, "Books");
                var bookPath = Path.Combine(booksFolder, "book.epub");

                if (!System.IO.File.Exists(bookPath))
                {
                    return NotFound();
                }

                var fileBytes = await System.IO.File.ReadAllBytesAsync(bookPath);
                return File(fileBytes, "application/epub+zip");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
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
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
