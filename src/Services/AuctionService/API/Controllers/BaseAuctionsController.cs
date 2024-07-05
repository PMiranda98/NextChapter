﻿using Application.DTOs.Output;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseAuctionsController : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>(); 

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

        return BadRequest(result.Error);
    }
}
