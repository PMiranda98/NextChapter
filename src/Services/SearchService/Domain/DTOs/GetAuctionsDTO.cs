using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetAuctionsDTO
    {
        public IReadOnlyList<Auction> Auctions { get; set; }
        public long TotalCount { get; set; }
        public int PageCount { get; set; }
    }
}
