﻿using Persistence.Configuration;
using Application.Configuration;
using EventBus.Configuration;


namespace API.Extensions
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(corsOpt =>
            {
                corsOpt.AddPolicy("CorsPolicy", corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });


            services.AddApplicationDependencies();
            services.AddPersistenceDependencies(configuration);
            services.AddEventBusDependencies(configuration);

            return services;
        }
    }
}
