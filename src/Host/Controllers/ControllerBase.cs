using MediatR;

namespace Host.Controllers;

public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    protected readonly IMediator Mediator;

    public ControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }
}