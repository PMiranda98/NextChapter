using Application.Auctions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseSearchController
    {
        [HttpGet] //api/search or api/search?searchTerm=
        public async Task<IActionResult> GetAuctions(CancellationToken cancellationToken, string? searchTerm, int pageNumber = 1, int pageSize = 3)
        {
            if (searchTerm == null)
                return HandleResult(await Mediator.Send(new List.Query { SearchTerm = null, PageNumber = pageNumber, PageSize = pageSize }, cancellationToken));
            else
                return HandleResult(await Mediator.Send(new List.Query { SearchTerm = searchTerm, PageNumber = pageNumber, PageSize = pageSize }, cancellationToken));
        }
    }
}
