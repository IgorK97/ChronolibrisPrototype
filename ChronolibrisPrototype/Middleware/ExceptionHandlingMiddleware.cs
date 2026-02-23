using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChronolibrisPrototype.Middleware
{
    /// <summary>
    /// Middleware для централизованной обработки исключений в конвейере HTTP-запросов.
    /// Перехватывает необработанные исключения, логирует их и возвращает стандартизированный ответ 500 Internal Server Error
    /// в формате ProblemDetails.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ExceptionHandlingMiddleware"/>.
        /// </summary>
        /// <param name="next">Следующий делегат в конвейере запросов.</param>
        /// <param name="logger">Интерфейс логирования для записи ошибок.</param>
        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        /// <summary>
        /// Вызывает следующий делегат в конвейере. Оборачивает вызов в блок try-catch
        /// для перехвата любых необработанных исключений.
        /// </summary>
        /// <param name="context">Текущий HTTP-контекст.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task InvokeAsync(HttpContext context)
        {


            //await _next(context);


            try
            {
                _logger.LogInformation("➡️ {Method} {Path} | Query: {Query} | User: {User}",
                    context.Request.Method,
                    context.Request.Path,
                    context.Request.QueryString,
                    context.User.Identity?.Name ?? "anonymous");

                var sw = Stopwatch.StartNew();
                await _next(context);

                sw.Stop();

                _logger.LogInformation("✅ {Method} {Path} → {StatusCode} ({Elapsed}ms)",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    sw.ElapsedMilliseconds);
            }

            catch (Exception exception)
            {
                _logger.LogError(
                     exception,
                    "Error processing {Method} {Path}." +
                    " Query: {QueryString}. Message: {Message}",
                    context.Request.Method,
                    context.Request.Path,
                    context.Request.QueryString,
                    exception.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Unexpected server Error"
                };

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
