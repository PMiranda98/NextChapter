using Application.DTOs.Input.Auctions;
using Application.DTOs.Input.Bids;
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
            CreateMap<AuctionCreated, Auction>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<ItemCreated, Item>();

            CreateMap<AuctionUpdated, UpdatedAuctionDto>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<ItemUpdated, UpdatedItemDto>();

            CreateMap<BidPlaced, BidPlacedDto>();

            CreateMap<AuctionFinished, FinishedAuctionDto>();
   
        }
    }
}
