using AutoMapper;
using Domain.DTOs.Input.Advertisement;
using Domain.DTOs.Input.Item;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UpdateAdvertisementDto, Advertisement>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<UpdateItemDto, Item>();
        }
    }
}
