using System.ComponentModel.DataAnnotations;
using AuctionService.Domain.DTOs.Item;

namespace AuctionService.Domain.DTOs.Auction;

public class CreateAuctionDto
{
  [Required]
  public int ReservePrice { get; set; }
  [Required]
  public DateTime AuctionEnd { get; set; }
  [Required]
  public CreateItemDto Item { get; set; }
}
