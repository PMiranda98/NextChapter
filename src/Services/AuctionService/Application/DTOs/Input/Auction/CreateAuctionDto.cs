using System.ComponentModel.DataAnnotations;
using Application.DTOs.Input.Item;

namespace Application.DTOs.Input.Auction;

public class CreateAuctionDto
{
    [Required]
    public int ReservePrice { get; set; }
    [Required]
    public DateTime AuctionEnd { get; set; }
    [Required]
    public required CreateItemDto Item { get; set; }
}
