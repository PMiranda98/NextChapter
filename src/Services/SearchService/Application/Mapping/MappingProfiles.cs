using Application.DTOs.Input.Auctions;
using Application.DTOs.Output.Auctions;
using AutoMapper;
using Domain.Repositories.Models;

namespace Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SearchAuctionsInputDTO, SearchAuctionsParams>();
            CreateMap<SearchAuctionsOutput, SearchAuctionsOutputDTO>();
        }
    }
}
