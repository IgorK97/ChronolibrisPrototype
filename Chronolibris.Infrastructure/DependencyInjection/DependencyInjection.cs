using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Chronolibris.Infrastructure.Persistance;
using Chronolibris.Infrastructure.Persistance.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chronolibris.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

                options.UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IGenericRepository<Content>, GenericRepository<Content>>();
            services.AddScoped<IGenericRepository<Review>, GenericRepository<Review>>();
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
            services.AddScoped<IGenericRepository<Publisher>, GenericRepository<Publisher>>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddIdentityRealization(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<long>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
