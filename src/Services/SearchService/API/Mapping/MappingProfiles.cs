using API.RequestHelpers;
using Application.DTOs.Input.Auctions;
using AutoMapper;

namespace API.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SearchParams, SearchAuctionsInputDTO>();
        }
    }
}
