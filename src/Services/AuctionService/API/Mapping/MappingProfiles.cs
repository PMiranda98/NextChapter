using Application.DTOs.Input.Auction;
using Application.DTOs.Input.Item;
using Application.DTOs.Output.Auction;
using Application.DTOs.Output.Item;
using AuctionService.Domain.Entities;
using AutoMapper;

namespace API.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAuctionDto, Auction>().IncludeMembers(x => x.Item);
        CreateMap<CreateItemDto, Auction>();
        CreateMap<CreateItemDto, Item>();

        CreateMap<UpdateAuctionDto, Auction>()
            .IncludeMembers(x => x.Item)
            .ForAllMembers(opts => opts.MapFrom((src, dest, srcMember, destMember) => srcMember ?? destMember));
        CreateMap<UpdateItemDto, Auction>()
            .ForAllMembers(opts => opts.MapFrom((src, dest, srcMember, destMember) => srcMember ?? destMember));
        CreateMap<UpdateItemDto, Item>()
            .ForAllMembers(opts => opts.MapFrom((src, dest, srcMember, destMember) => srcMember ?? destMember));
    }
}
