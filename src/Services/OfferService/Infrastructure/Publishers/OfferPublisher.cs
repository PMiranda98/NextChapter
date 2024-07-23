using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using EventBus.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Publishers
{
    public class OfferPublisher : IOfferPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public OfferPublisher(IPublishEndpoint publishEndpoint, IMapper mapper) 
        {
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }
        public async Task PublishOfferPlaced(Offer offer)
        {
            var offerPlaced = _mapper.Map<OfferPlaced>(offer);
            await _publishEndpoint.Publish(offerPlaced);
        }
    }
}
