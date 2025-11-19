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

namespace Chronolibris.Infrastructure.Seed
{
    public static class InitialDatabaseSeeder
    {
        public static async Task InitialSeedDatabase(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            //Потом не забыть сделать так, чтобы была таблица __EFSeedHistory
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<long>>>();
            if (!context.Roles.Any())
            {

                await roleManager.CreateAsync(new IdentityRole<long>("admin"));
                await roleManager.CreateAsync(new IdentityRole<long>("reader"));
            }

            if (!userManager.Users.Any())
            {
                var dt = DateTime.UtcNow;
                var adminUser = new ApplicationUser
                {
                    FamilyName = "KQWERTY",
                    IsDeleted = false,
                    LastEnteredAt = dt,
                    Name = "AQWERTY",
                    RegisteredAt = dt,
                    Email = "mail@mail.com",
                    UserName="MainAdmin",
                    EmailConfirmed=true,

                };
                var password = configuration["DefaultUser:AdminPassword"];

                var result = await userManager.CreateAsync(adminUser, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "admin");
                }
                else
                {

                    throw new Exception("Failed to create default admin user: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            await DataDatabaseSeeder.LanguageSeedDatabase(context);
            await DataDatabaseSeeder.CountrySeedDatabase(context);
            await DataDatabaseSeeder.PersonSeedDatabase(context);
            await DataDatabaseSeeder.PublisherSeedDatabase(context);
            await DataDatabaseSeeder.TagTypeSeedDatabase(context);
            await DataDatabaseSeeder.ThemeSeedDatabase(context);
            await DataDatabaseSeeder.ContentsSeedDatabase(context);
            await DataDatabaseSeeder.BooksSeedDatabase(context);
            await DataDatabaseSeeder.SelectionSeedDatabase(context);
        }

        
    }
}
