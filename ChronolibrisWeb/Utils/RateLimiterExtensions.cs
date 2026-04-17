using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

namespace ChronolibrisWeb.Utils
{
    public static class RateLimiterExtensions
    {
        public static void AddChronolibrisRateLimiter(this RateLimiterOptions
            options)
        {
            options.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = 429;
                await context.HttpContext.Response.
                    WriteAsync("Слишком много запросов. Попробуйте позже",
                    token);
            };
            AddUserPolicy(options, "bookmarks", permitLimit: 1, 1);
            AddUserPolicy(options, "comments", 5, 60);
            AddUserPolicy(options, "ratings", 10, 60);
            AddUserPolicy(options, "reports", 1, 60);
        }

        private static void AddUserPolicy(RateLimiterOptions options,
            string name, int permitLimit, int secondsCount)
        {
            options.AddPolicy(name, httpContext =>
            {
                var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var key = userId != null ? $"{name}:user:{userId}"
                : $"{name}:ip:{httpContext.Connection.RemoteIpAddress}";

                return RateLimitPartition.GetSlidingWindowLimiter
                (key, _ => new SlidingWindowRateLimiterOptions
                {
                    PermitLimit = permitLimit,
                    Window = TimeSpan.FromSeconds(secondsCount),
                    SegmentsPerWindow = 2,
                    QueueLimit = 0
                });
            });
        }
    }
}