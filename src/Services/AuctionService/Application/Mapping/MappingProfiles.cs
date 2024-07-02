using Application.DTOs.Input.Auction;
using Application.DTOs.Input.Item;
using Application.DTOs.Output.Auction;
using Application.DTOs.Output.Item;
using AuctionService.Domain.Entities;
using AutoMapper;

namespace Application.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionDto>();
        CreateMap<Item, ItemDto>();

        CreateMap<CreateAuctionDto, Auction>().IncludeMembers(x => x.Item);
        CreateMap<CreateItemDto, Auction>();
        CreateMap<CreateItemDto, Item>();

        CreateMap<UpdateAuctionDto, Auction>().IncludeMembers(x => x.Item);
        CreateMap<UpdateItemDto, Auction>();
        CreateMap<UpdateItemDto, Item>();
    }
}
