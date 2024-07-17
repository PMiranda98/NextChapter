using Domain.DTOs.Input.Item;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Input.Auction;

public class UpdateAuctionDto
{
    [Required]
    public required UpdateItemDto Item { get; set; }
}
