using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Input.Auctions
{
    public class FinishedAuctionDto
    {
        public bool ItemSold { get; set; }
        public required string AuctionId { get; set; }
        public string? Winner { get; set; }
        public required string Seller { get; set; }
        public int? Amount { get; set; }
    }
}
