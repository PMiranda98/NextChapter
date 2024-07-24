using AdvertisementService;
using Application.Interfaces;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GrpcAdvertisementClient : IGrpcAdvertisementClient
    {
        private readonly ILogger<GrpcAdvertisementClient> _logger;
        private readonly IConfiguration _configuration;

        public GrpcAdvertisementClient(ILogger<GrpcAdvertisementClient> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public bool AdvertisementExists(string id)
        {
            _logger.LogInformation($"=====> Calling Grpc service to verify existance of Advertisement: {id}");
            var channel = GrpcChannel.ForAddress(_configuration["GrpcAdvertisement"]);
            var client = new GrpcAdvertisement.GrpcAdvertisementClient(channel);
            var request = new GrpcAdvertisementExistsRequest { Id = id };

            try
            {
                var reply = client.AdvertisementExists(request);
                return reply == null ? false : reply.Exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not call gRPC server");
                return false;
            }
        }
    }
}
