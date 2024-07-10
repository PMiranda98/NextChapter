using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Input.Bids
{
    public class PlacedBidDto
    {
        public required string Id { get; set; }
        public required string AuctionId { get; set; }
        public required string Bidder { get; set; }
        public required DateTime BidTime { get; set; }
        public required int Amount { get; set; }
        public required string BidStatus { get; set; }
    }
}
