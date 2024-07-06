using Persistence.Configuration;
using Application.Configuration;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;


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
            services.AddInfrastructureDependencies();

            return services;
        }
    }
}
