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
            CreateMap<Auction, AuctionCreated>();
            CreateMap<Item, AuctionCreated>();
            CreateMap<Item, ItemCreated>();

            CreateMap<Auction, AuctionUpdated>();
            CreateMap<Item, AuctionUpdated>();
            CreateMap<Item, ItemUpdated>();
        }
    }
}
