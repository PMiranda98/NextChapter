using Application.Configuration;
using Persistence.Configuration;
using EventBus.Configuration;
using Infrastructure.Configuration;

namespace API.Extensions
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddApplicationDependencies();
            services.AddPersistenceDependencies();
            services.AddInfrastructureDependencies();

            return services;
        }
    }
}
