using AuctionService.Application.Auctions.Validators;
using AuctionService.Application.Core;
using AuctionService.Domain.DTOs.Auction;
using AuctionService.Domain.Entities;
using AuctionService.Persistence.Data;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AuctionService.Application.Auctions;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public CreateAuctionDto CreateAuctionDto { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.CreateAuctionDto).SetValidator(new CreateAuctionDtoValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public Handler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = new Auction();
            _mapper.Map(request.CreateAuctionDto, auction);

            _dataContext.Auctions.Add(auction);
            var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to create Auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
