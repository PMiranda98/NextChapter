using AutoMapper;
using Domain.Entities;
using EventBus.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Offer, OfferPlaced>();
        }
    }
}
