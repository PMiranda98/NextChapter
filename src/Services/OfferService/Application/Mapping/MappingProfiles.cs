﻿using AutoMapper;
using Domain.DTOs.Input.Item;
using Domain.DTOs.Input.Offer;
using Domain.DTOs.Input.Photo;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Item;
using Domain.DTOs.Output.Offer;
using Domain.DTOs.Output.Photo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOfferDto, Offer>()
                .ForMember(dest => dest.ItemsToExchange, opt => opt.MapFrom(src => src.ItemsToExchange));
            CreateMap<CreateItemDto, Item>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));
            CreateMap<CreatePhotoDto, Photo>();

            CreateMap<UpdateOfferDto, Offer>()
                .ForMember(dest => dest.ItemsToExchange, opt => opt.MapFrom(src => src.ItemsToExchange));
            CreateMap<UpdateItemDto, Item>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));
            CreateMap<UpdatePhotoDto, Photo>();

            CreateMap<Offer,CreatedOfferDto>()
                .ForMember(dest => dest.ItemsToExchange, opt => opt.MapFrom(src => src.ItemsToExchange));
            CreateMap<Item, CreatedItemDto>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));
            CreateMap<Photo, CreatedPhotoDto>();

            CreateMap<Offer,OfferDto>()
                .ForMember(dest => dest.ItemsToExchange, opt => opt.MapFrom(src => src.ItemsToExchange));
            CreateMap<Item, ItemDto>()
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));
            CreateMap<Photo, PhotoDto>();

            CreateMap<SearchOutputDTO<Offer>, SearchOutputDTO<OfferDto>>();
        }
    }
}
