using Infrastructure.Shell.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[Authorize(AuthenticationSchemes = "ApiKey")]
public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    private readonly IMediator _mediator;

    public ControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> Send<T>(IRequest<T> request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        catch (NonZeroExitCodeException e)
        {
            return Problem(title: e.Details.Message, detail: e.Details.Error);
        }
    }
}