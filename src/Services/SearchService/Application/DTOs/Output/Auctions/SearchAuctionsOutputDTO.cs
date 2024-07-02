using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Output.Auctions
{
    public class SearchAuctionsOutputDTO
    {
        public IReadOnlyList<Auction>? Auctions { get; set; }
        public long TotalCount { get; set; }
        public int PageCount { get; set; }
    }
}
