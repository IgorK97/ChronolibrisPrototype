using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Chronolibris.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавляет MediatR и регистрирует все Handlers, Behaviors и Notifications 
        /// из Application-сборки.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns>Текущая коллекция сервисов.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Получаем ссылку на текущую сборку (Application-слой)
            Assembly applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

            // Регистрируем MediatR
            services.AddMediatR(cfg =>
            {
                // Регистрируем все Handlers, Queries, Commands и Behaviors 
                // из Application-сборки.
                cfg.RegisterServicesFromAssembly(applicationAssembly);
            });

            // Добавьте сюда регистрацию других сервисов Application-слоя, если необходимо.
            // services.AddScoped<IMyAppService, MyAppService>();

            return services;
        }
    }
}
