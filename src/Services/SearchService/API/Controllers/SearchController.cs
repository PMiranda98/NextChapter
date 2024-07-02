using API.RequestHelpers;
using Application.Auctions;
using Application.DTOs.Input.Auctions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseSearchController
    {
        private readonly IMapper _mapper;

        public SearchController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet] //api/search or api/search?searchTerm=
        public async Task<IActionResult> Search([FromQuery]SearchParams searchParams, CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new List.Query { SearchAuctionsInputDTO = _mapper.Map<SearchAuctionsInputDTO>(searchParams) }, cancellationToken));
        }
    }
}
