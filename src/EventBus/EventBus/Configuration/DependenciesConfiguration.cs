using MassTransit;
using Microsoft.EntityFrameworkCore;
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
                config.requiredConfiguration();
            });

            return services;
        }

        public static IServiceCollection AddEventBusDependencies<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddMassTransit(config =>
            {
                config.requiredConfiguration();
                
                config.AddEntityFrameworkOutbox<T>(cfg =>
                {
                    // If some message go to the Outbox (bacause of a failure in the event bus or something elese) this will enforce going to that Outbox x at x time check if there is some message to retry to send.
                    cfg.QueryDelay = TimeSpan.FromSeconds(30);
                    cfg.UsePostgres();
                    cfg.UseBusOutbox();
                });
            });

            return services;
        }

        private static IBusRegistrationConfigurator requiredConfiguration(this IBusRegistrationConfigurator config)
        {
            var consumersAssembly = Assembly.Load("Infrastructure");
            config.AddConsumers(consumersAssembly);

            config.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(Environment.GetEnvironmentVariable("SERVICE_NAME"), false));

            config.UsingRabbitMq((context, config) =>
            {
                config.ConfigureEndpoints(context);
            });
            return config;
        }
    }
}
