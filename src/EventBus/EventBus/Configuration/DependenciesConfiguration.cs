using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventBus.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddEventBusDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(config =>
            {
                config.AddConsumers(Assembly.GetEntryAssembly());

                config.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(Environment.GetEnvironmentVariable("SERVICE_NAME"), false));

                config.UsingRabbitMq((context, config) =>
                {
                    config.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
