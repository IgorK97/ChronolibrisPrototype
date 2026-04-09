using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChronolibrisPrototype.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
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
