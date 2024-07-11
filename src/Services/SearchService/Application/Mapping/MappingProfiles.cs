using Application.DTOs.Input;
using Application.DTOs.Input.Auctions;
using Application.DTOs.Input.Item;
using Application.DTOs.Output;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Models;

namespace Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SearchInputDTO, SearchParams>();
            CreateMap<SearchOutput<Auction>, SearchOutputDTO<Auction>>();

            CreateMap<UpdatedAuctionDto, Auction>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<UpdatedItemDto, Item>();
        }
    }
}
