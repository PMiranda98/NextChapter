﻿using Application.Configuration;
using Infrastructure.Configuration;
using Infrastructure.Photos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Persistence.Configuration;

namespace API.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = configuration["IdentityServiceUrl"];
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters.ValidateAudience = false;
                    options.TokenValidationParameters.NameClaimType = "username";
                });

            services.AddApplicationDependencies();
            services.AddPersistenceDependencies(configuration);
            services.AddInfrastructureDependencies(configuration);

            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));

            return services;
        }
    }
}
