using System.ComponentModel.DataAnnotations;
using Domain.DTOs.Input.Item;

namespace Domain.DTOs.Input.Auction;

public class CreateAuctionDto
{
    public Guid Id { get; set; }
    [Required]
    public int ReservePrice { get; set; }
    [Required]
    public DateTime AuctionEnd { get; set; }
    [Required]
    public required CreateItemDto Item { get; set; }
}
