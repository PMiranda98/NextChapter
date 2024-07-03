using API.RequestHelpers;
using Application.Auctions;
using Application.DTOs.Input.Auctions;
using AutoMapper;
using Domain.Entities;
using EventBus.Contracts;
using EventBus.Contracts.Models;

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
