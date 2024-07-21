using AdvertisementService.Domain.Entities;
using AutoMapper;
using Domain.DTOs.Input.Advertisement;
using Domain.DTOs.Input.Offer;
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
            CreateMap<Item, ItemCreated>();

            CreateMap<Advertisement, AdvertisementUpdated>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<Item, ItemUpdated>();

            CreateMap<AdvertisementFinished, FinishedAdvertisementDto>();

            CreateMap<OfferPlaced, OfferPlacedDto>();
        }
    }
}
