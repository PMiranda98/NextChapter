using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
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
        public async Task<GetAuctionsDTO> SearchAll(int pageNumber, int pageSize)
        {
            var query = DB.PagedSearch<Auction>().Sort(x => x.Ascending(a => a.Item.Make));
            query.PageNumber(pageNumber);
            query.PageSize(pageSize);
            return await GetResult(query);
        }

        public async Task<GetAuctionsDTO> SearchTerm(string searchTerm, int pageNumber, int pageSize)
        {
            var query = DB.PagedSearch<Auction>().Match(Search.Full, searchTerm).SortByTextScore();
            query.PageNumber(pageNumber);
            query.PageSize(pageSize);
            return await GetResult(query);
            
        }

        private async Task<GetAuctionsDTO> GetResult(PagedSearch<Auction, Auction>? query)
        {
            var result = await query.ExecuteAsync();
            var resultDto = new GetAuctionsDTO
            {
                Auctions = result.Results,
                PageCount = result.PageCount,
                TotalCount = result.TotalCount
            };
            return resultDto;
        }
    }
}
