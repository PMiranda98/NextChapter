﻿using Application.DTOs.Input.Auction;
using AuctionService.Application.Auctions;
using AuctionService.Persistence.Data;
using AutoMapper;
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

  [HttpPost] //api/auctions
  public async Task<IActionResult> Create(CreateAuctionDto createAuctionDto, CancellationToken cancellationToken)
  {
    return HandleResult(await Mediator.Send(new Create.Command { CreateAuctionDto = createAuctionDto }, cancellationToken), nameof(Get));
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Edit(Guid id, UpdateAuctionDto updateAuctionDto, CancellationToken cancellationToken)
  {
    return HandleResult(await Mediator.Send(new  Edit.Command { UpdateAuctionDto = updateAuctionDto, Id = id }, cancellationToken));
  }

  [HttpDelete("{id}")] //api/auctions/id
  public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
  {
    return HandleResult(await Mediator.Send(new Delete.Command { Id = id }, cancellationToken));
  }
}
