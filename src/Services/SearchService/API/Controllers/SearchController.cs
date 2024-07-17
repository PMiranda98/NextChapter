using API.RequestHelpers;
using Application.DTOs.Input;
using Application.Handlers.Auctions;
using AutoMapper;
using Domain.DTOs.Input;
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
            return HandleResult(await Mediator.Send(new List.Query { SearchInputDTO = _mapper.Map<SearchInputDTO>(searchParams) }, cancellationToken));
        }
    }
}
