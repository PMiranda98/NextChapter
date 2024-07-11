using API.RequestHelpers;
using Application.DTOs.Input;
using AutoMapper;

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
