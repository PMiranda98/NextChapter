using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    /*
     * "Background Service: Base class for implementing a long running IHostedService"
     * This is going to run as a singleton. It's goingto run When the application starts up and
     * it's only going to stop when our application shuts down.
     */
    public class BackgroundServiceCheckOfferDate : BackgroundService
    {
        private readonly ILogger<BackgroundServiceCheckOfferDate> _logger;
        private readonly IServiceProvider _serviceProvider;

        public BackgroundServiceCheckOfferDate(ILogger<BackgroundServiceCheckOfferDate> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            /*
             * The offer repository it's going to be used here. As the repository service has a scoped lifetime and we are in 
             * a singleton service, we need to get the service instead of injecting it.
             */
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("====> Starting check for offer date");

            // Just to retrive information to lets us know that the offer date check is stopping
            stoppingToken.Register(() => { _logger.LogInformation("====> Stopping check for offer date"); });

            while (!stoppingToken.IsCancellationRequested)
            {
                await CheckOfferDate(stoppingToken);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task CheckOfferDate(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IOfferRepository>();

            var offersToBeRejected = await repository.ListOffersNeededToBeRejected(stoppingToken);
            if (offersToBeRejected.Any())
            {
                _logger.LogInformation("====> Found {count} offers that need to be rejected", offersToBeRejected.Count);

                foreach(var offer in offersToBeRejected)
                {
                    offer.Status = OfferStatus.Rejected;
                }

                await repository.SaveChangesAsync(stoppingToken);
            } else
            {
                _logger.LogInformation("=====> There aren't any offers that need to be rejected.");
            }
        }
    }
}
