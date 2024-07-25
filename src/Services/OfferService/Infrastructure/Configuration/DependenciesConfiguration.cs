using Application.Interfaces;
using EventBus.Configuration;
using Infrastructure.Publishers;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEventBusDependencies<DataContext>(configuration);

            services.AddScoped<IOfferPublisher, OfferPublisher>();

            services.AddScoped<IGrpcAdvertisementClient, GrpcAdvertisementClient>();

            services.AddHostedService<BackgroundServiceCheckOfferDate>();

            return services;
        }
    }
}
