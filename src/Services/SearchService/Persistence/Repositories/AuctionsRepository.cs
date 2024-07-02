using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Models;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AuctionsRepository : IAuctionsRepository
    {
        public async Task<SearchAuctionsOutput> SearchAuctions(SearchAuctionsParams searchAuctionsParams)
        {
            var query = DB.PagedSearch<Auction, Auction>();
            if (searchAuctionsParams.SearchTerm != null)
                query.Match(Search.Full, searchAuctionsParams.SearchTerm);

            //Filtering
            switch (searchAuctionsParams.FilterBy)
            {
                case "finished": query.Match(x => x.AuctionEnd < DateTime.UtcNow); break;
                case "endingSoon": query.Match(x => x.AuctionEnd < DateTime.UtcNow.AddHours(3) && x.AuctionEnd > DateTime.UtcNow); break;
                default: query.Match(x => x.AuctionEnd > DateTime.UtcNow); break;
            }

            if (!string.IsNullOrEmpty(searchAuctionsParams.Seller))
            {
                query.Match(x => x.Seller == searchAuctionsParams.Seller);
            }

            if (!string.IsNullOrEmpty(searchAuctionsParams.Winner))
            {
                query.Match(x => x.Winner == searchAuctionsParams.Winner);
            }

            // Sorting
            switch (searchAuctionsParams.OrderBy)
            {
                case "make":  query.Sort(x => x.Ascending(a => a.Item.Make)); break;
                case "new": query.Sort(x => x.Descending(a => a.CreatedAt)); break;
                default: query.Sort(x=> x.Ascending(a => a.AuctionEnd)); break;
            }

            query.PageNumber(searchAuctionsParams.PageNumber);
            query.PageSize(searchAuctionsParams.PageSize);
            return await GetOutput(query);
        }

        public async Task CreateAuction(Auction auction)
        {
            await auction.SaveAsync();
        } 

        private async Task<SearchAuctionsOutput> GetOutput(PagedSearch<Auction, Auction>? query)
        {
            var resultDto = new SearchAuctionsOutput();
            if(query != null)
            {
                var result = await query.ExecuteAsync();
                resultDto = new SearchAuctionsOutput
                {
                    Auctions = result.Results,
                    PageCount = result.PageCount,
                    TotalCount = result.TotalCount
                };
                return resultDto;
            }
            return resultDto;
        }
    }
}
