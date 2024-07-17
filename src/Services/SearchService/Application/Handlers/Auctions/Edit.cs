using Application.DTOs.Input.Auctions;
using AutoMapper;
using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Auctions
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdatedAuctionDto UpdatedAuctionDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IAuctionsRepository _auctionsRepository;
            private readonly IMapper _mapper;

            public Handler(IAuctionsRepository auctionsRepository, IMapper mapper)
            {
                _auctionsRepository = auctionsRepository;
                _mapper = mapper;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var auction = await _auctionsRepository.DetailsAuction(request.UpdatedAuctionDto.Id.ToString());
                if (auction == null) return null;
                auction = _mapper.Map(request.UpdatedAuctionDto, auction);

                await _auctionsRepository.UpdateAuction(auction);
                // TODO - Error handling 
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
