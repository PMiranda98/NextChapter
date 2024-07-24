using AdvertisementService;
using Application.Handlers.Advertisements;
using Grpc.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GrpcAdvertisementService : GrpcAdvertisement.GrpcAdvertisementBase
    {
        private readonly IMediator _mediator;

        public GrpcAdvertisementService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<GrpcAdvertisementExistsResponse> AdvertisementExists(GrpcAdvertisementExistsRequest request, ServerCallContext context)
        {
            Console.WriteLine("==> Received Grpc request for Advertisement");
            var exists = await _mediator.Send(new Exists.Query { Id = request.Id });
            return new GrpcAdvertisementExistsResponse
            {
                Exists = exists
            };
        }
    }
}
