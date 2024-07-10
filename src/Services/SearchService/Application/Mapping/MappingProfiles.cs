using Application.DTOs.Input.Auctions;
using Application.DTOs.Input.Item;
using Application.DTOs.Output.Auctions;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Models;

namespace Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SearchAuctionsInputDTO, SearchAuctionsParams>();
            CreateMap<SearchAuctionsOutput, SearchAuctionsOutputDTO>();

            CreateMap<UpdatedAuctionDto, Auction>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<UpdatedItemDto, Item>();
        }
    }
}
