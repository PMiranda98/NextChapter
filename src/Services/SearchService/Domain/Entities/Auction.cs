using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Auction : Entity
    {
        public int ReservePrice { get; set; }
        public string? Seller { get; set; }
        public string? Winner { get; set; }
        public int SoldAmount { get; set; }
        public int CurrentHighBid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime AuctionEnd { get; set; }
        public string? Status { get; set; }
        public required Item Item { get; set; }
    }
}
