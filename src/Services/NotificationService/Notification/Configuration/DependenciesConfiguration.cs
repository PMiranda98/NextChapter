using Infrastructure.Configuration;

namespace Notification.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureDependencies(configuration);

            services.AddSignalR();

            return services;
        }
    }
}
