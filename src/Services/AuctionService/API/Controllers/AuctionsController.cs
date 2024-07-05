using Application.DTOs.Input.Auction;
using AuctionService.Application.Auctions;
using AuctionService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

public class AuctionsController : BaseAuctionsController
{
    [HttpGet] //api/auctions
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
    return HandleResult(await Mediator.Send(new List.Query(), cancellationToken));
    }

    [HttpGet("{id}")] //api/auctions/id
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
    return HandleResult(await Mediator.Send(new Details.Query { Id = id }, cancellationToken));
    }

    [Authorize]
    [HttpPost] //api/auctions
    public async Task<IActionResult> Create(CreateAuctionDto createAuctionDto, CancellationToken cancellationToken)
    {
        var auction = Mapper.Map<Auction>(createAuctionDto);
        auction.Seller = User.Identity.Name;

        return HandleResult(await Mediator.Send(new Create.Command { Auction = auction }, cancellationToken));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, UpdateAuctionDto updateAuctionDto, CancellationToken cancellationToken)
    {
        var auction = Mapper.Map<Auction>(updateAuctionDto);
        //auction.Seller == != User.Identity.Name) return Forbid("")

        return HandleResult(await Mediator.Send(new  Edit.Command { Auction = auction, Id = id }, cancellationToken));
    }

    [Authorize]
    [HttpDelete("{id}")] //api/auctions/id
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        //auction.Seller == != User.Identity.Name) return Forbid("")
        return HandleResult(await Mediator.Send(new Delete.Command { Id = id }, cancellationToken));
    }
}
