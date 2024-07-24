using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventBus.Configuration;
using Application.Interfaces;
using Infrastructure.Publishers;
using AdvertisementService.Persistence.Data;

namespace Infrastructure.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEventBusDependencies<DataContext>(configuration);

            services.AddScoped<IAdvertisementPublisher, AdvertisementPublisher>();

            services.AddGrpc();

            return services;
        }
    }
}
