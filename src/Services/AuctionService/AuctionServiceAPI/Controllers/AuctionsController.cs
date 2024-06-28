using AuctionService.Domain.DTOs.Auction;
using AuctionService.Persistence.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

public class AuctionsController : BaseApiController
{
  private readonly ILogger<AuctionsController> _logger;
  private readonly AuctionDbContext _context;
  private readonly IMapper _mapper;

  public AuctionsController(ILogger<AuctionsController> logger, AuctionDbContext context, IMapper mapper)
  {
    _logger = logger;
    _context = context;
    _mapper = mapper;
  }

  [HttpGet] //api/auctions
  public async Task<IActionResult> Get(CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  [HttpGet("{id}")] //api/auctions/id
  public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  [HttpPost] //api/auctions
  public async Task<IActionResult> Create(CreateAuctionDto createAuctionDto, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Edit(Guid id, UpdateAuctionDto updateAuctionDto, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  [HttpDelete("{id}")] //api/auctions/id
  public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
