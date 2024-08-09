using AutoMapper;
using Domain.DTOs.Input.Item;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Item;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Item, ItemDto>()
            .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));

        CreateMap<Item, CreatedItemDto>()
            .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo));
        
        CreateMap<CreateItemDto, Item>();

        CreateMap<UpdateItemDto, Item>();

        CreateMap<SearchOutputDTO<Item>, SearchOutputDTO<ItemDto>>();
    }
}