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

            CreateMap<AuctionUpdated, Auction>();
            CreateMap<ItemUpdated, Auction>();
            CreateMap<ItemUpdated, Item>();
        }
    }
}
