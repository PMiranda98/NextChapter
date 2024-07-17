using API.RequestHelpers;
using Application.DTOs.Input;
using AutoMapper;
using Domain.DTOs.Input;

namespace API.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SearchParams, SearchInputDTO>();
        }
    }
}
