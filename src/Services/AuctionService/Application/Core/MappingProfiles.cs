using AuctionService.Domain.DTOs.Auction;
using AuctionService.Domain.DTOs.Item;
using AuctionService.Domain.Entities;
using AutoMapper;

namespace AuctionService.Application.Core;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
    CreateMap<AuctionDto, Auction>().IncludeMembers(x => x.Item);
    CreateMap<Item, ItemDto>();
    CreateMap<CreateAuctionDto, Auction>().IncludeMembers(x => x.Item);
    CreateMap<CreateItemDto, Item>();
    CreateMap<UpdateAuctionDto, Auction>().IncludeMembers(x => x.Item);
    CreateMap<UpdateItemDto, Item>();
  }
}
