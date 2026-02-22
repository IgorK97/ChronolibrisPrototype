using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chronolibris.Infrastructure.DataAccess.BackgroundServices
{
    public class TokenCleanupService : BackgroundService
    {
        private readonly IServiceProvider _services;
        //private readonly IServiceScopeFactory _scopeFactory;
        private readonly TimeSpan _checkInterval = TimeSpan.FromHours(24);

        public TokenCleanupService(IServiceProvider services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var now = DateTime.UtcNow;
                    var expiredTokens = db.TokenBlacklist
                        .Where(t => t.Expiry < now);

                    if (expiredTokens.Any())
                    {
                        db.TokenBlacklist.RemoveRange(expiredTokens);
                        await db.SaveChangesAsync(stoppingToken);
                    }
                }

                await Task.Delay(_checkInterval, stoppingToken);
            }
        }
    }

}
