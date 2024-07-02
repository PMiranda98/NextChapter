using AuctionService.Domain.Entities;
using AutoMapper;
using EventBus.Contracts;
using EventBus.Contracts.Models;

namespace Persistence.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Event bus maps
            CreateMap<Auction, AuctionCreated>();
            CreateMap<Item, AuctionCreated>();
            CreateMap<Item, ItemCreated>();
        }
    }
}
