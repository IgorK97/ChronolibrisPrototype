using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chronolibris.Application.Interfaces;
using Chronolibris.Domain.Entities;
using Chronolibris.Domain.Interfaces;
using Chronolibris.Infrastructure.Data;
using Chronolibris.Infrastructure.Files;
using Chronolibris.Infrastructure.Identity;
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
            //services.AddScoped<IGenericRepository<Review>, GenericRepository<Review>>();
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
            services.AddScoped<IGenericRepository<Publisher>, GenericRepository<Publisher>>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<IReviewsRatingRepository,  ReviewsRatingRepository>();
            services.AddScoped<IReviewRepository,  ReviewRepository>();
            services.AddScoped<ISelectionsRepository, SelectionsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddIdentityRealization(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddIdentity<ApplicationUser, IdentityRole<long>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddFileProviderInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var booksFolder = configuration["BooksFolder"] ?? throw new InvalidOperationException("BooksFolder not configured.");
            services.AddSingleton<IBookFileProvider>(new BookFileProvider(booksFolder));

            return services;
        }

    //    public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services,
    //IConfiguration configuration)
    //    {
    //        services.AddScoped<IIdentityService, IdentityService>();
    //        services.AddIdentity<ApplicationUser, IdentityRole<long>>()
    //                .AddEntityFrameworkStores<ApplicationDbContext>()
    //                .AddDefaultTokenProviders();

    //        return services;
    //    }
    }
}
