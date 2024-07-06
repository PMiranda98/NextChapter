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

        CreateMap<UpdateItemDto, Item>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        CreateMap<UpdateAuctionDto, Auction>()
            .ForMember(dest => dest.Item, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
    }
}
