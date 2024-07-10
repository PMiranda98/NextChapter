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
        CreateMap<Auction, AuctionDto>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<Item, ItemDto>();

        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<CreateItemDto, Item>();

        CreateMap<UpdateAuctionDto, Auction>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<UpdateItemDto, Item>();
    }
}