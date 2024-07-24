using Domain.Entities;
using Domain.Repositories;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly DataContext _dataContext;

        public OfferRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task CreateOffer(Offer offer, CancellationToken cancellationToken)
        {
            await _dataContext.Offers.AddAsync(offer);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
