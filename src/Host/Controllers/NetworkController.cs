using Domain.Commands.Docker.Network;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("[controller]")]
public class NetworkController : ControllerBase
{
    public NetworkController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Remove all unused networks 
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Prune()
    {
        return await Send(new NetworkPruneCommand());
    }
}