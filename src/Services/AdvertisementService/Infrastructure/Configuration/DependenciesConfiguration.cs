using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventBus.Configuration;
using Application.Interfaces;
using Infrastructure.Publishers;
using AdvertisementService.Persistence.Data;
using Infrastructure.Photos;

namespace Infrastructure.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEventBusDependencies<DataContext>(configuration);

            services.AddScoped<IAdvertisementPublisher, AdvertisementPublisher>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();

            services.AddGrpc();

            return services;
        }
    }
}
