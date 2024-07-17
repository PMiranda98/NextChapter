using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.Entities;
using MongoDB.Entities;

namespace Domain.Repositories
{
    public interface IAuctionsRepository
    {
        public Task<SearchOutputDTO<Auction>> SearchAuctions(SearchInputDTO searchAuctionsParams);
        public Task CreateAuction(Auction auction);
        public Task UpdateAuction(Auction auction);
        public Task DeleteAuction(string Id);
        public Task<Auction?> DetailsAuction(string Id);
        public Task SaveAsync<T>(T data) where T : Entity;
    }
}
