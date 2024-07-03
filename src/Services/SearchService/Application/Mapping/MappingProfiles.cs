using Application.DTOs.Input.Auctions;
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

            CreateMap<Auction, Auction>()
            .IncludeMembers(x => x.Item)
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Item, Auction>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Item, Item>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
