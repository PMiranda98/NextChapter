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
        public async Task<SearchDto> SearchAll(int pageNumber, int pageSize)
        {
            var query = DB.PagedSearch<Auction>();
            query.PageNumber(pageNumber);
            query.PageSize(pageSize);
            return await GetResult(query);
        }

        public async Task<SearchDto> SearchByTerm(string searchTerm, int pageNumber, int pageSize)
        {
            var query = DB.PagedSearch<Auction>().Match(Search.Full, searchTerm);
            query.PageNumber(pageNumber);
            query.PageSize(pageSize);
            return await GetResult(query);
        }

        private async Task<SearchDto> GetResult(PagedSearch<Auction, Auction>? query)
        {
            var resultDto = new SearchDto();
            if(query != null)
            {
                var result = await query.ExecuteAsync();
                resultDto = new SearchDto
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
