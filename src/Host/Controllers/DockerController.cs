using Domain.Commands.Docker;
using Domain.Queries.Docker;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("[controller]")]
public class DockerController : ControllerBase
{
    public DockerController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// List all containers
    /// </summary>
    /// <returns>A list of all containers</returns>
    [HttpGet("containers")]
    public async Task<IActionResult> List()
    {
        return await Send(new DockerContainerListQuery());
    }

    /// <summary>
    /// Inspect a container
    /// </summary>
    /// <returns>Detailed information about the container with the specified id</returns>
    [HttpGet("inspect/{id}")]
    public async Task<IActionResult> Inspect(string id)
    {
        return await Send(new DockerInspectQuery(id));
    }

    /// <summary>
    /// Start a container
    /// </summary>
    [HttpPut("start/{id}")]
    public async Task<IActionResult> Start(string id)
    {
        return await Send(new DockerStartCommand(id));
    }

    /// <summary>
    /// Stop a container
    /// </summary>
    [HttpPut("stop/{id}")]
    public async Task<IActionResult> Stop(string id)
    {
        return await Send(new DockerStopCommand(id));
    }

    /// <summary>
    /// Restart a container
    /// </summary>
    [HttpPut("restart/{id}")]
    public async Task<IActionResult> Restart(string id)
    {
        return await Send(new DockerRestartCommand(id));
    }
}