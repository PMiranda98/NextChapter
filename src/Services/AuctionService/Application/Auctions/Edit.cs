using AuctionService.Application.Auctions.Validators;
using AuctionService.Application.Core;
using AuctionService.Domain.DTOs.Auction;
using AuctionService.Persistence.Data;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AuctionService.Application.Auctions;

public class Edit
{
    public class Command : IRequest<Result<Unit>?>
    {
        public Guid Id { get; set; }
        public UpdateAuctionDto UpdateAuctionDto { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.UpdateAuctionDto).SetValidator(new UpdateAuctionDtoValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>?>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public Handler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = await _dataContext.Auctions.FindAsync(request.Id);
            if (auction == null) return null;
            _mapper.Map(request.UpdateAuctionDto, auction);
            // TODO - Check if the ItemDto related field are updated too.

            var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to update the auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
