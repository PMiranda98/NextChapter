using API.RequestHelpers;
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
