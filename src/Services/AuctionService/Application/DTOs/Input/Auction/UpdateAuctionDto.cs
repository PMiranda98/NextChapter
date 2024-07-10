using Application.DTOs.Input.Item;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Input.Auction;

public class UpdateAuctionDto
{
    [Required]
    public required UpdateItemDto Item { get; set; }
}
