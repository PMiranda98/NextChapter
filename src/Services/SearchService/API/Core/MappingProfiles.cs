using API.RequestHelpers;
using Application.Auctions;
using AutoMapper;

namespace API.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SearchParams, List.QueryParams>();
        }
    }
}
