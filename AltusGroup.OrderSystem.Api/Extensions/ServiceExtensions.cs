#region Namespace imports

using AltusGroup.OrderSystem.Data.Context;
using AltusGroup.OrderSystem.Repositories;
using AltusGroup.OrderSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

#endregion

namespace AltusGroup.OrderSystem.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<DbOrdersContext>(o =>
                o.UseInMemoryDatabase(databaseName: "Orders")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                ); 

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Altus Group Order System API",
                    Version = "v1"
                });
            });

            return services;
        }
    }
}
