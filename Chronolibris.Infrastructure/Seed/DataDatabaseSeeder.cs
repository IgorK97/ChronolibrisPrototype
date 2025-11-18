using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chronolibris.Infrastructure.Seed
{
    public class DataDatabaseSeeder
    {
        public static async Task ThemeSeedDatabase(ApplicationDbContext context)
        {

        }

        public static async Task LanguageSeedDatabase(ApplicationDbContext context)
        {

        }
        public static async Task CountrySeedDatabase(ApplicationDbContext context)
        {

        }
        public static async Task ContentsSeedDatabase(ApplicationDbContext context)
        {

        }
        public static async Task BooksSeedDatabase(ApplicationDbContext context)
        {
 
            //var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        }

        public static async Task SelectionSeedDatabase(ApplicationDbContext context)
        {

        }

        public static async Task PersonSeedDatabase(ApplicationDbContext context)
        {

        }

        public static async Task PublisherSeedDatabase(ApplicationDbContext context)
        {

        }

        public static async Task TagTypeSeedDatabase(ApplicationDbContext context)
        {

        }
    }
}
