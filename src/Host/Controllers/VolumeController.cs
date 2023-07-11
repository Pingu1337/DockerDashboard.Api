using Domain.Commands.Docker.Volume;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("[controller]")]
public class VolumeController : ControllerBase
{
    public VolumeController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Prune anonymous volumes
    /// </summary>
    /// <param name="all">Remove all unused volumes, not just anonymous ones</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Prune([FromQuery] bool all = false)
    {
        return await Send(new VolumePruneCommand(all));
    }
}