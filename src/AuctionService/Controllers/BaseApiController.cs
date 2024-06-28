using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseApiController : ControllerBase
{
  private readonly ILogger<BaseApiController> _logger;

    public BaseApiController(ILogger<BaseApiController> logger)
    {
        _logger = logger;
    }
}
