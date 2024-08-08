using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;

        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task CreateItem(Item item, CancellationToken cancellationToken)
        {
            await _dataContext.Items.AddAsync(item, cancellationToken);
        }

        public async Task DeleteItem(Guid Id, CancellationToken cancellationToken)
        {
            var advertisement = await _dataContext.Items.FindAsync(Id, cancellationToken);
            if (advertisement != null)
                _dataContext.Items.Remove(advertisement);
        }

        public async Task<Item?> DetailsItem(Guid Id, CancellationToken cancellationToken)
        {
            return await _dataContext.Items.Include(x => x.Photo).Where(x => x.Id == Id).FirstAsync(cancellationToken) ?? null;
        }

        public async Task<Item?> DetailsItem(string Id, CancellationToken cancellationToken)
        {
            return await _dataContext.Items.Include(x => x.Photo).Where(x => x.Id.ToString() == Id).FirstAsync(cancellationToken) ?? null;
        }

        public async Task<Item?> FindItem(string Id, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(Id, out Guid id))
            {
                return await _dataContext.Items.FindAsync(id, cancellationToken) ?? null;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Item>> ListItem(CancellationToken cancellationToken)
        {
            return await _dataContext.Items.Include(x => x.Photo).OrderBy(x => x.Name).ToListAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
