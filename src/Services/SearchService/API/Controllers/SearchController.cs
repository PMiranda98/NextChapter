using API.RequestHelpers;
using Application.Handlers.Advertisements;
using AutoMapper;
using Domain.DTOs.Input;
using Domain.DTOs.Output;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SearchController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet] //api/search or api/search?searchTerm=
        public async Task<IActionResult> Search([FromQuery]SearchParams searchParams, CancellationToken cancellationToken)
        {
            return HandleResult(await _mediator.Send(new List.Query { SearchInputDTO = _mapper.Map<SearchInputDTO>(searchParams) }, cancellationToken));
        }

        private ActionResult HandleResult<T>(Result<T>? result, string? uri = null)
        {
            if (result == null) return NotFound();

            if (result.IsSuccess && result.Value != null)
            {
                switch (HttpContext.Request.Method)
                {
                    case "GET":
                        return Ok(result.Value);
                    case "POST":
                        return CreatedAtAction(uri, result.Value);
                    case "PUT":
                        return Ok();
                    case "DELETE":
                        return Ok();
                }
            }

            if (result.IsSuccess && result.Value == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}
