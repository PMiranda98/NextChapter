using Application.Handlers.Advertisements;
using Domain.DTOs.Input.Advertisement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementService.Controllers;

public class AdvertisementController : BaseAdvertisementController
{
    [HttpGet] //api/advertisement
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
    return HandleResult(await Mediator.Send(new List.Query(), cancellationToken));
    }

    [HttpGet("{id}")] //api/advertisement/id
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
    return HandleResult(await Mediator.Send(new Details.Query { Id = id }, cancellationToken));
    }

    [Authorize]
    [HttpPost] //api/advertisement
    public async Task<IActionResult> Create(CreateAdvertisementDto createAdvertisementDto, CancellationToken cancellationToken)
    {
        return HandleResult(await Mediator.Send(new Create.Command { CreateAdvertisementDto = createAdvertisementDto, Seller = User.Identity.Name }, cancellationToken));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, UpdateAdvertisementDto updateAdvertisementDto, CancellationToken cancellationToken)
    {
        return HandleResult(await Mediator.Send(new  Edit.Command { UpdateAdvertisementDto = updateAdvertisementDto, Id = id, User=User.Identity.Name }, cancellationToken));
    }

    [Authorize]
    [HttpDelete("{id}")] //api/advertisement/id
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = id, User=User.Identity.Name }, cancellationToken));
    }
}
