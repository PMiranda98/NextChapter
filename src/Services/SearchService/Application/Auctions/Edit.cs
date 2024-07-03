using Application.DTOs.Output;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Auctions
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Auction Auction { get; set; }
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
                var auction = await _auctionsRepository.DetailsAuction(request.Auction.ID);
                if (auction != null) return null;
                auction = _mapper.Map<Auction>(request.Auction);

                await _auctionsRepository.UpdateAuction(request.Auction);
                // TODO - Error handling 
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
