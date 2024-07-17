using Application.Handlers.Auctions;
using AuctionService.Domain.Entities;
using Domain.DTOs.Input.Auction;
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
        return HandleResult(await Mediator.Send(new Create.Command { CreateAuctionDto = createAuctionDto, Seller = User.Identity.Name }, cancellationToken));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, UpdateAuctionDto updateAuctionDto, CancellationToken cancellationToken)
    {
        return HandleResult(await Mediator.Send(new  Edit.Command { UpdateAuctionDto = updateAuctionDto, Id = id, User=User.Identity.Name }, cancellationToken));
    }

    [Authorize]
    [HttpDelete("{id}")] //api/auctions/id
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = id, User=User.Identity.Name }, cancellationToken));
    }
}
