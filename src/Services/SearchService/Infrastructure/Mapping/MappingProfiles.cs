using Application.DTOs.Input.Advertisements;
using Application.DTOs.Input.Item;
using Application.DTOs.Input.Offers;
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
            CreateMap<AdvertisementCreated, Advertisement>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<ItemCreated, Item>();

            CreateMap<AdvertisementUpdated, UpdatedAdvertisementDto>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<ItemUpdated, UpdatedItemDto>();

            CreateMap<OfferPlaced, PlacedOfferDto>();

            CreateMap<AdvertisementFinished, FinishedAdvertisementDto>();
   
        }
    }
}
