﻿using Application.DTOs.Input.Auction;
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

        CreateMap<UpdateAuctionDto, Auction>()
            .IncludeMembers(x => x.Item)
            .ForAllMembers(opts => opts.MapFrom((src, dest, srcMember, destMember) => srcMember ?? destMember));
        CreateMap<UpdateItemDto, Auction>()
            .ForAllMembers(opts => opts.MapFrom((src, dest, srcMember, destMember) => srcMember ?? destMember));
        CreateMap<UpdateItemDto, Item>()
            .ForAllMembers(opts => opts.MapFrom((src, dest, srcMember, destMember) => srcMember ?? destMember));
    }
}
