using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.Entities;
using MongoDB.Entities;

namespace Domain.Repositories
{
    public interface IAdvertisementRepository
    {
        public Task<SearchOutputDTO<Advertisement>> SearchAdvertisement(SearchInputDTO searchAdvertisementParams);
        public Task CreateAdvertisement(Advertisement advertisement);
        public Task UpdateAdvertisement(Advertisement advertisement);
        public Task DeleteAdvertisement(string Id);
        public Task<Advertisement?> DetailsAdvertisement(string Id);
        public Task SaveAsync<T>(T data) where T : Entity;
    }
}
