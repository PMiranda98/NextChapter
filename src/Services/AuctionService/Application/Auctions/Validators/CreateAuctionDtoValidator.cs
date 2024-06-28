using AuctionService.Domain.DTOs.Auction;
using FluentValidation;

namespace AuctionService.Application.Auctions.Validators;

public class CreateAuctionDtoValidator : AbstractValidator<CreateAuctionDto>
    {
        public CreateAuctionDtoValidator() 
        { 
            //RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.Type).NotEmpty();
        }
    }