using Chronolibris.Application.Interfaces;
using Chronolibris.Infrastructure.Data;
using Chronolibris.Infrastructure.Identity;
using ChronolibrisPrototype.Services;
using Microsoft.AspNetCore.Identity;

namespace ChronolibrisPrototype.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCdnService(this IServiceCollection services)
        {
            services.AddSingleton<ICdnService, CdnService>();

            return services;
        }
    }
}
