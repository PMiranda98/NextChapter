using Application.DTOs.Input.Auction;
using FluentValidation;

namespace AuctionService.Application.Auctions.Validators;

public class UpdateAuctionDtoValidator : AbstractValidator<UpdateAuctionDto>
    {
        public UpdateAuctionDtoValidator() 
        { 
            //RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.Type).NotEmpty();
        }
    }