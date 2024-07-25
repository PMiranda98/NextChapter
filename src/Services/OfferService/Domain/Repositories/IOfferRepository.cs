using Domain.DTOs.Output.Offer;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOfferRepository
    {
        public Task CreateOffer(Offer offer, CancellationToken cancellationToken);
        public Task<List<Offer>> ListOffersByAdvertisement(string advertisementId, CancellationToken cancellationToken);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public Task<List<Offer>> ListOffersNeededToBeRejected(CancellationToken cancellationToken);
    }
}
