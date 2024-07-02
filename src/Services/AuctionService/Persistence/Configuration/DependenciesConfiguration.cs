using AuctionService.Persistence.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IAuctionsRepository, AuctionsRepository>();

            return services;
        }
    }
}
