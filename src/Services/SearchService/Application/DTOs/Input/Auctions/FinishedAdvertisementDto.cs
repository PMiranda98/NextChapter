using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Input.Advertisements
{
    public class FinishedAdvertisementDto
    {
        public bool ItemSold { get; set; }
        public required string AdvertisementId { get; set; }
        public string? Buyer { get; set; }
        public required string Seller { get; set; }
        public int? Amount { get; set; }
    }
}
