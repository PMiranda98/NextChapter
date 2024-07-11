using Domain.Entities;
using Domain.Repositories.Models;
using MongoDB.Entities;

namespace Domain.Repositories
{
    public interface IAuctionsRepository
    {
        public Task<SearchOutput<Auction>> SearchAuctions(SearchParams searchAuctionsParams);
        public Task CreateAuction(Auction auction);
        public Task UpdateAuction(Auction auction);
        public Task DeleteAuction(string Id);
        public Task<Auction?> DetailsAuction(string Id);
        public Task SaveAsync<T>(T data) where T : Entity;
    }
}
