using Domain.DTOs.Output;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseAdvertisementController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected ActionResult HandleResult<T> (Result<T>? result, string? uri = null)
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
