using Application.DTOs.Input.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Input.Auctions
{
    public class UpdatedAuctionDto
    {
        public Guid Id { get; set; }
        public UpdatedItemDto? Item { get; set; }
    }
}
