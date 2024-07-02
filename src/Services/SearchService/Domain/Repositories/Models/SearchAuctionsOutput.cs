using Domain.Entities;

namespace Domain.Repositories.Models
{
    public class SearchAuctionsOutput
    {
        public IReadOnlyList<Auction>? Auctions { get; set; }
        public long TotalCount { get; set; }
        public int PageCount { get; set; }
    }
}
