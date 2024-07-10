using Application.DTOs.Output;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Auctions
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IAuctionsRepository _auctionsRepository;

            public Handler(IAuctionsRepository auctionsRepository)
            {
                _auctionsRepository = auctionsRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _auctionsRepository.DeleteAuction(request.Id);
                // TODO - Error handling 
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
