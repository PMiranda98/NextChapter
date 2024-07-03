using Domain.Entities;
using Domain.Repositories.Models;

namespace Domain.Repositories
{
    public interface IAuctionsRepository
    {
        public Task<SearchAuctionsOutput> SearchAuctions(SearchAuctionsParams searchAuctionsParams);
        public Task CreateAuction(Auction auction);
        public Task UpdateAuction(Auction auction);
        public Task DeleteAuction(string Id);
        public Task<Auction?> DetailsAuction(string Id);
    }
}
