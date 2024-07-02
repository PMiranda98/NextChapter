using Domain.Repositories.Models;

namespace Domain.Repositories
{
    public interface IAuctionsRepository
    {
        Task<SearchAuctionsOutput> SearchAuctions(SearchAuctionsParams searchAuctionsParams);
    }
}
