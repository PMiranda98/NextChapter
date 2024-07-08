using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EventBus.Configuration
{
    public static class DependenciesConfiguration
    {
        /// <summary>
        /// Event bus dependencies configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEventBusDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(config =>
            {
                config.requiredConfiguration(configuration);
            });

            return services;
        }

        /// <summary>
        /// Event bus dependencies configuration that will config a Bus Outbox for a DbContext type.
        /// </summary>
        /// <typeparam name="T">An object that inherits from DbContext.</typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEventBusDependencies<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddMassTransit(config =>
            {
                config.requiredConfiguration(configuration);
                
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

        /// <summary>
        /// Common configuration to all publishers and subscribers.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private static IBusRegistrationConfigurator requiredConfiguration(this IBusRegistrationConfigurator config, IConfiguration configuration)
        {
            var consumersAssembly = Assembly.Load("Infrastructure");
            config.AddConsumers(consumersAssembly);
            config.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(configuration["ServiceName"], false));

            config.UsingRabbitMq((context, config) =>
            {
                config.Host(configuration["RabbitMq:Host"], "/", host =>
                {
                    var username = configuration["RabbitMq:Username"];
                    if(string.IsNullOrEmpty(username)) username = "guest";
                    var password = configuration["RabbitMq:Password"];
                    if (string.IsNullOrEmpty(password)) password = "guest";
                    host.Username(username);
                    host.Password(password);
                 });

                // Configuration of retry policies on the consumers.
                // This will try to consume the message from the event bus if the previous consumption of that message had an error.
                // After some time it will stop retrying and it will set the message on a event bus queue specific for errors of that type of message.
                var consumers = GetConsumersTypes(consumersAssembly);
                foreach (var consumer in consumers)
                {
                    var queueName = ConvertToKebabCaseWithPrefix(Environment.GetEnvironmentVariable("SERVICE_NAME"), consumer.Name);
                    config.ReceiveEndpoint(queueName, cfg =>
                    {
                        cfg.UseMessageRetry(r => r.Interval(5, 5));

                        cfg.ConfigureConsumer(context, consumer);
                    });

                };
                config.ConfigureEndpoints(context);
            });
            return config;
        }
        /// <summary>
        /// Get all the types that are consumers.
        /// </summary>
        /// <param name="assembly">Assembly where the search will be done.</param>
        /// <returns></returns>
        private static IEnumerable<Type> GetConsumersTypes(Assembly assembly)
        {
            // get all types implementing IConsumer<T> in the assembly
            return assembly.GetTypes()
                .Where(x => x.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConsumer<>)))
                .ToList();
        }
       
        private static string ConvertToKebabCaseWithPrefix(string? prefix, string input)
        {
            var formatter = new KebabCaseEndpointNameFormatter(string.Empty, false);
            string sanitizedInput = formatter.SanitizeName(input);
            // Remove the "-consumer" part if needed
            sanitizedInput = Regex.Replace(sanitizedInput, "-consumer$", string.Empty);
            return $"{prefix}-{sanitizedInput}";
        }
    }
}
