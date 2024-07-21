using AdvertisementService.Domain.Entities;
using Application.Interfaces;
using AutoMapper;
using Domain.DTOs.Input.Advertisement;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Advertisement;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements;

public class Create
{
    public class Command : IRequest<Result<CreatedAdvertisementDto?>>
    {
        public required CreateAdvertisementDto CreateAdvertisementDto { get; set; }
        public required string Seller { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<CreatedAdvertisementDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepository _auctionsRepository;
        private readonly IAdvertisementPublisher _auctionsPublisher;

        public Handler(IMapper mapper, IAdvertisementRepository auctionsRepository, IAdvertisementPublisher auctionsPublisher)
        {
            _mapper = mapper;
            _auctionsRepository = auctionsRepository;
            _auctionsPublisher = auctionsPublisher;
        }

        public async Task<Result<CreatedAdvertisementDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = _mapper.Map<Advertisement>(request.CreateAdvertisementDto);
            auction.Seller = request.Seller;
            _auctionsRepository.CreateAdvertisement(auction, cancellationToken);
            await _auctionsPublisher.PublishAdvertisementCreated(auction);

            var result = await _auctionsRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<CreatedAdvertisementDto>.Failure("Failed to create Auction!");

            var createdAuctionDto = _mapper.Map<CreatedAdvertisementDto>(request.CreateAdvertisementDto);
            createdAuctionDto.Id = auction.Id;
            return Result<CreatedAdvertisementDto>.Success(createdAuctionDto);
        }
    }
}
