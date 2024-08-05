using Application.Handlers.Advertisements;
using Domain.DTOs.Input.Advertisement;
using Domain.DTOs.Output;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdvertisementService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdvertisementController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdvertisementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet] //api/advertisement
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
    return HandleResult(await _mediator.Send(new List.Query(), cancellationToken));
    }

    [HttpGet("{id}")] //api/advertisement/id
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
    return HandleResult(await _mediator.Send(new Details.Query { Id = id }, cancellationToken));
    }

    [Authorize]
    [HttpPost] //api/advertisement
    public async Task<IActionResult> Create([FromForm] IFormFile file, [FromForm] string createAdvertisementDtoJson, CancellationToken cancellationToken)
    {
        var createAdvertisementDto = JsonConvert.DeserializeObject<CreateAdvertisementDto>(createAdvertisementDtoJson);
        if (createAdvertisementDto == null || !TryValidateModel(createAdvertisementDto))
        {
            return BadRequest(ModelState);
        }

        return HandleResult(await _mediator.Send(new Create.Command { CreateAdvertisementDto = createAdvertisementDto, File=file, Seller = User.Identity.Name }, cancellationToken));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromForm] IFormFile file, [FromForm] string updateAdvertisementDtoJson, CancellationToken cancellationToken)
    {
        var updateAdvertisementDto = JsonConvert.DeserializeObject<UpdateAdvertisementDto>(updateAdvertisementDtoJson);        
        if(updateAdvertisementDto == null || !TryValidateModel(updateAdvertisementDto))
        {
            return BadRequest(ModelState);
        }

        return HandleResult(await _mediator.Send(new  Edit.Command { UpdateAdvertisementDto = updateAdvertisementDto, File=file, Id = id, User=User.Identity.Name }, cancellationToken));
    }

    [Authorize]
    [HttpDelete("{id}")] //api/advertisement/id
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await _mediator.Send(new Delete.Command { Id = id, User=User.Identity.Name }, cancellationToken));
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

        if (!result.IsSuccess)
        {
            switch (result.ErrorCode)
            {
                case "403":
                    return Forbid();
                case "401":
                    return Unauthorized(result.Error);
            }
        }

        return BadRequest(result.Error);
    }
}
