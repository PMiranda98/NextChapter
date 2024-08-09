using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Item;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IItemRepository
    {
        public Task CreateItem(Item item, CancellationToken cancellationToken);
        //public Task UpdateAdvertisement(CancellationToken cancellationToken);
        public Task DeleteItem(Guid Id, CancellationToken cancellationToken);
        public Task<SearchOutputDTO<Item>> ListItem(SearchInputDTO searchItemsParams, CancellationToken cancellationToken);
        public Task<Item?> DetailsItem(Guid Id, CancellationToken cancellationToken);
        public Task<Item?> DetailsItem(string Id, CancellationToken cancellationToken);
        public Task<Item?> FindItem(string Id, CancellationToken cancellationToken);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
