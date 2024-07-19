using AuctionService.Domain.Entities;
using AutoMapper;
using Domain.DTOs.Input.Auction;
using Domain.DTOs.Input.Item;
using Domain.DTOs.Output.Auction;
using Domain.DTOs.Output.Item;

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

        CreateMap<CreateAuctionDto, CreatedAuctionDto>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<CreateItemDto, CreatedItemDto>();

        CreateMap<UpdateAuctionDto, Auction>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<UpdateItemDto, Item>();
    }
}