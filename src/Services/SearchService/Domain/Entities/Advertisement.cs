using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Advertisement : Entity
    {

        public int SellingPrice { get; set; }
        public string? Seller { get; set; }
        public string? Buyer { get; set; }
        public int? SoldAmount { get; set; }
        public int NumberOfOffers { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public required string Status { get; set; }
        public required Item Item { get; set; }
    }
}
