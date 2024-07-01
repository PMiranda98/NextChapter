using AuctionService.Application.Auctions;
using AuctionService.Persistence.Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using Application.Configuration;

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

            return services;
        }
    }
}
