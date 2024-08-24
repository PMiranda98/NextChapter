using API.RequestHelpers;
using Application.Handlers.Items;
using AutoMapper;
using Domain.DTOs.Input;
using Domain.DTOs.Input.Item;
using Domain.DTOs.Output;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InventoryController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet] //api/inventory
        public async Task<IActionResult> Get([FromQuery] SearchParams searchParams, CancellationToken cancellationToken)
        {
            return HandleResult(await _mediator.Send(new List.Query { SearchInputDTO = _mapper.Map<SearchInputDTO>(searchParams) }, cancellationToken));
        }

        [HttpGet("{id}")] //api/inventory/id
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            return HandleResult(await _mediator.Send(new Details.Query { Id = id }, cancellationToken));
        }

        [Authorize]
        [HttpPost] //api/inventory
        public async Task<IActionResult> Create([FromForm] IFormFile file, [FromForm] string createItemDtoJson, CancellationToken cancellationToken)
        {
            var createItemDto = JsonConvert.DeserializeObject<CreateItemDto>(createItemDtoJson);
            if (createItemDto == null || !TryValidateModel(createItemDto))
            {
                return BadRequest(ModelState);
            }

            return HandleResult(await _mediator.Send(new Create.Command { CreateItemDto = createItemDto, File = file, Owner = User.Identity.Name }, cancellationToken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromForm] IFormFile file, [FromForm] string updateItemDtoJson, CancellationToken cancellationToken)
        {
            var updateItemDto = JsonConvert.DeserializeObject<UpdateItemDto>(updateItemDtoJson);
            if (updateItemDto == null || !TryValidateModel(updateItemDto))
            {
                return BadRequest(ModelState);
            }

            return HandleResult(await _mediator.Send(new Edit.Command { UpdateItemDto = updateItemDto, File = file, Id = id, User = User.Identity.Name }, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")] //api/inventory/id
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return HandleResult(await _mediator.Send(new Delete.Command { Id = id, User = User.Identity.Name }, cancellationToken));
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
