using Application.Configuration;
using Persistence.Configuration;

namespace API.Extensions
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddApplicationDependencies();
            services.AddPersistenceDependencies();

            return services;
        }
    }
}
