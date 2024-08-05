using Application.DTOs.Input.Advertisement;
using AutoMapper;
using Domain.DTOs.Input.Advertisement;
using Domain.DTOs.Input.Item;
using Domain.DTOs.Input.Offer;
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
            CreateMap<ItemCreated, Item>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));

            CreateMap<EventBus.Contracts.Models.Photo, Domain.Entities.Photo>();

            CreateMap<AdvertisementUpdated, UpdateAdvertisementDto>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<ItemUpdated, UpdateItemDto>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));

            CreateMap<OfferPlaced, PlacedOfferDto>();

            CreateMap<AdvertisementFinished, FinishedAdvertisementDto>();
   
        }
    }
}
