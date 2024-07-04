using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventBus.Configuration;
using Application.Interfaces;
using Infrastructure.Publishers;
using AuctionService.Persistence.Data;

namespace Infrastructure.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddEventBusDependencies<DataContext>();

            services.AddScoped<IAuctionsPublisher, AuctionsPublisher>();

            return services;
        }
    }
}
