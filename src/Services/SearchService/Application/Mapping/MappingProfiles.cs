using Application.DTOs.Input.Advertisements;
using Application.DTOs.Input.Item;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UpdatedAdvertisementDto, Advertisement>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<UpdatedItemDto, Item>();
        }
    }
}
