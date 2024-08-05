using AdvertisementService.Domain.Entities;
using AutoMapper;
using Domain.DTOs.Input.Advertisement;
using Domain.DTOs.Input.Item;
using Domain.DTOs.Output.Advertisement;
using Domain.DTOs.Output.Item;

namespace Application.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Advertisement, AdvertisementDto>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<Item, ItemDto>()
            .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));

        CreateMap<CreateAdvertisementDto, Advertisement>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<CreateItemDto, Item>();

        CreateMap<Advertisement, CreatedAdvertisementDto>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<Item, CreatedItemDto>()
            .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));

        CreateMap<UpdateAdvertisementDto, Advertisement>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
        CreateMap<UpdateItemDto, Item>();
    }
}