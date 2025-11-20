using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chronolibris.Infrastructure.DatabaseChecker
{
    public static class DatabaseChecker
    {
        public static async Task CheckDatabase(IServiceProvider serviceProvider, IConfiguration configuration)
        {

            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //await context.Database.EnsureCreatedAsync();
            await context.Database.MigrateAsync();
  

        }

        
    }
}
