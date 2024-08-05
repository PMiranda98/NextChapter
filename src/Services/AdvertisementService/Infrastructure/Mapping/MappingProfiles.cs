using AdvertisementService.Domain.Entities;
using AutoMapper;
using Domain.DTOs.Input.Advertisement;
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
            CreateMap<Advertisement, AdvertisementCreated>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<Item, ItemCreated>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));

            CreateMap<Domain.Entities.Photo, EventBus.Contracts.Models.Photo>();

            CreateMap<Advertisement, AdvertisementUpdated>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<Item, ItemUpdated>();

            CreateMap<AdvertisementFinished, FinishedAdvertisementDto>();

            CreateMap<OfferPlaced, OfferPlacedDto>();
        }
    }
}
