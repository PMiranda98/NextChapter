using API.RequestHelpers;
using Application.Auctions;
using Application.DTOs.Input.Auctions;
using AutoMapper;

namespace API.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SearchParams, SearchAuctionsInputDTO>();
        }
    }
}
