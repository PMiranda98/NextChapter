﻿using Application.DTOs.Input.Advertisement;
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
            CreateMap<ItemCreated, Item>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));

            CreateMap<EventBus.Contracts.Models.Photo, Domain.Entities.Photo>();

            CreateMap<AdvertisementUpdated, UpdatedAdvertisementDto>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<ItemUpdated, UpdatedItemDto>();

            CreateMap<OfferPlaced, PlacedOfferDto>();

            CreateMap<AdvertisementFinished, FinishedAdvertisementDto>();
   
        }
    }
}
