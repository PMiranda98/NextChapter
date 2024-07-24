using Application.Handlers.Offers;
using Domain.DTOs.Input.Offer;
using Domain.DTOs.Output;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("{advertisementId}")]
        public async Task<IActionResult> Create(Guid advertisementId, CreateOfferDto createOfferDto, CancellationToken cancellationToken)
        {
            return HandleResult(await _mediator.Send(new Create.Command { CreateOfferDto = createOfferDto, Buyer = User.Identity.Name, AdvertisementId = advertisementId }, cancellationToken));
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
}
