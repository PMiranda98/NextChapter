using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Offer>> ListOffersByAdvertisement(string advertisementId, CancellationToken cancellationToken)
        {
            return await _dataContext.Offers.Where(p => p.AdvertisementId == advertisementId).ToListAsync(cancellationToken);
        }

        public async Task<SearchOutputDTO<Offer>> ListOffers(SearchInputDTO searchOfferParams, string username, CancellationToken cancellationToken)
        {

            IQueryable<Offer>? query = null;
            
            switch (searchOfferParams.Direction)
            {
                case "sent": query = _dataContext.Offers.Where(x => x.Sender == username); break;
                case "received": query = _dataContext.Offers.Where(x => x.Recipient == username); break;
            }

            switch (searchOfferParams.Status)
            {
                case OfferStatus.Live: query = query.Where(x => x.Status == OfferStatus.Live); break;
                case OfferStatus.Archived: query = query.Where(x => x.Status == OfferStatus.Archived); break;
                case OfferStatus.Rejected: query = query.Where(x => x.Status == OfferStatus.Rejected); break;
                case OfferStatus.Accepted: query = query.Where(x => x.Status == OfferStatus.Accepted); break;
            }

            query = query
                .Skip((searchOfferParams.PageNumber - 1) * searchOfferParams.PageSize)
                .Take(searchOfferParams.PageSize)
                .Include(x => x.ItemsToExchange);

            var results = await query.ToListAsync(cancellationToken);

            if (searchOfferParams.OrderBy == "new")
                results = results.OrderBy(x => x.CreatedAt).ToList();

            var totalCount = 0;
            if (searchOfferParams.Direction == "sent")
                totalCount = _dataContext.Offers.Where(x => x.Sender == username).Count();
            else if (searchOfferParams.Direction == "received")
                totalCount = _dataContext.Offers.Where(x => x.Recipient == username).Count();

            var resultDto = new SearchOutputDTO<Offer>()
            {
                PageCount = (int)Math.Ceiling((totalCount * 1.0) / searchOfferParams.PageSize),
                TotalCount = totalCount,
                Results = results
            };

            return resultDto;
        }

        public async Task<List<Offer>> ListOffersNeededToBeRejected(CancellationToken cancellationToken)
        {
            //return await _dataContext.Offers.Where(p => p.Status == OfferStatus.Live && (DateTime.UtcNow - p.Date).Days > 7).ToListAsync(cancellationToken);
            return await _dataContext.Offers.Where(p => p.Status == OfferStatus.Live && (DateTime.UtcNow - p.CreatedAt).Minutes > 60).ToListAsync(cancellationToken);
        }

        public async Task<Offer?> DetailsOffer(Guid Id, CancellationToken cancellationToken)
        {
            return await _dataContext.Offers.Include(x => x.ItemsToExchange).ThenInclude(y => y.Photo).Where(x => x.Id == Id).AsNoTracking().FirstAsync(cancellationToken) ?? null;
        }

        public async Task DeleteOffer(Guid Id, CancellationToken cancellationToken)
        {
            var offer = await _dataContext.Offers.FindAsync(Id, cancellationToken);
            if (offer != null)
                _dataContext.Offers.Remove(offer);
        }

        public async Task UpdateOffer(Offer offer, CancellationToken cancellationToken)
        {
            _dataContext.Entry(offer).State = EntityState.Modified;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {

            return await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
