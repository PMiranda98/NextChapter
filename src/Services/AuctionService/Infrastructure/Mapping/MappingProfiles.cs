using Application.DTOs.Input.Auction;
using Application.DTOs.Input.Bid;
using AuctionService.Domain.Entities;
using AutoMapper;
using EventBus.Contracts;
using EventBus.Contracts.Models;

namespace Infrastructure.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Event bus maps
            CreateMap<Auction, AuctionCreated>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<Item, ItemCreated>();

            CreateMap<Auction, AuctionUpdated>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<Item, ItemUpdated>();

            CreateMap<AuctionFinished, FinishedAuctionDto>();

            CreateMap<BidPlaced, BidPlacedDto>();
        }
    }
}
