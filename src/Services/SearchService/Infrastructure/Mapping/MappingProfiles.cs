using Application.DTOs.Input.Auctions;
using Application.DTOs.Input.Item;
using AutoMapper;
using Domain.Entities;
using EventBus.Contracts;
using EventBus.Contracts.Models;

namespace Infrastructure.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Event bus maps
            CreateMap<AuctionCreated, Auction>();
            CreateMap<ItemCreated, Auction>();
            CreateMap<ItemCreated, Item>();

            CreateMap<AuctionUpdated, UpdatedAuctionDto>()
                .IncludeMembers(x => x.Item);
            CreateMap<ItemUpdated, UpdatedAuctionDto>();
            CreateMap<ItemUpdated, UpdatedItemDto>();

            CreateMap<UpdatedAuctionDto, Auction>()
                .IncludeMembers(x => x.Item)
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdatedItemDto, Auction>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdatedItemDto, Item>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
