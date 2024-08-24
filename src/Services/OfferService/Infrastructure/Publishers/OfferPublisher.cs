using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using EventBus.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<OfferPublisher> _logger;

        public OfferPublisher(IPublishEndpoint publishEndpoint, IMapper mapper, ILogger<OfferPublisher> logger)  
        {
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task PublishOfferAccepted(Offer offer)
        {
            _logger.LogInformation($"=====> Publish Offer accepted: {offer.Id}");
            var offerAccepted = _mapper.Map<OfferAccepted>(offer);
            await _publishEndpoint.Publish(offerAccepted);
        }

        public async Task PublishOfferDeleted(Offer offer)
        {
            _logger.LogInformation($"=====> Publish Offer deleted: {offer.Id}");
            var offerDeleted = _mapper.Map<OfferDeleted>(offer);
            await _publishEndpoint.Publish(offerDeleted);
        }

        public async Task PublishOfferPlaced(Offer offer)
        {
            _logger.LogInformation($"=====> Publish Offer placed: {offer.Id}");
            var offerPlaced = _mapper.Map<OfferPlaced>(offer);
            await _publishEndpoint.Publish(offerPlaced);
        }
    }
}
