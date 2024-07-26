using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.Entities;
using Domain.Repositories;
using MongoDB.Entities;

namespace Persistence.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public async Task<SearchOutputDTO<Advertisement>> SearchAdvertisement(SearchInputDTO searchAdvertisementParams)
        {
            var query = DB.PagedSearch<Advertisement, Advertisement>();
            if (searchAdvertisementParams.SearchTerm != null)
                query.Match(Search.Full, searchAdvertisementParams.SearchTerm);

            //Filtering
            switch (searchAdvertisementParams.FilterBy)
            {
                case "sold": query.Match(x => x.Status == "Sold"); break;
                default: query.Match(x => x.Status == "Live"); break;
            }

            if (!string.IsNullOrEmpty(searchAdvertisementParams.Seller))
            {
                query.Match(x => x.Seller == searchAdvertisementParams.Seller);
            }

            if (!string.IsNullOrEmpty(searchAdvertisementParams.Buyer))
            {
                query.Match(x => x.Buyer == searchAdvertisementParams.Buyer);
            }

            // Sorting
            switch (searchAdvertisementParams.OrderBy)
            {
                case "new": query.Sort(x => x.Descending(a => a.CreatedAt)); break;
                default: query.Sort(x=> x.Ascending(a => a.Item.Name)); break;
            }

            query.PageNumber(searchAdvertisementParams.PageNumber);
            query.PageSize(searchAdvertisementParams.PageSize);
            return await GetOutput(query);
        }

        public async Task CreateAdvertisement(Advertisement advertisement)
        {
            await DB.SaveAsync(advertisement);
        }
        
        public async Task UpdateAdvertisement(Advertisement advertisement)
        {
            await DB.Update<Advertisement>()
                .Match(a => a.ID == advertisement.ID)
                .ModifyWith(advertisement)
                .ExecuteAsync();
        }

        public async Task DeleteAdvertisement(string Id)
        {
            await DB.DeleteAsync<Advertisement>(Id);
        }

        public async Task<Advertisement?> DetailsAdvertisement(string Id)
        {
            return await DB.Find<Advertisement>().Match(x => x.ID == Id).ExecuteFirstAsync();
        }

        private async Task<SearchOutputDTO<Advertisement>> GetOutput(PagedSearch<Advertisement, Advertisement>? query)
        {
            var resultDto = new SearchOutputDTO<Advertisement>();
            if(query != null)
            {
                var result = await query.ExecuteAsync();
                resultDto = new SearchOutputDTO<Advertisement>
                {
                    Results = result.Results,
                    PageCount = result.PageCount,
                    TotalCount = result.TotalCount
                };
                return resultDto;
            }
            return resultDto;
        }

        public async Task SaveAsync<T>(T data) where T : Entity
        {
            await DB.SaveAsync(data);
        }
    }
}
