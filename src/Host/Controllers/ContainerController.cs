using Domain.Commands.Docker;
using Domain.Commands.Docker.Container;
using Domain.Queries.Docker;
using Domain.Queries.Docker.Container;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("[controller]")]
public class ContainerController : ControllerBase
{
    public ContainerController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// List all containers
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> List()
    {
        return await Send(new ContainerListQuery());
    }

    /// <summary>
    /// Inspect a container
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> Inspect(string id)
    {
        return await Send(new ContainerInspectQuery(id));
    }
    
    /// <summary>
    /// Get the logs from a container
    /// </summary>
    [HttpGet("{id}/logs")]
    public async Task<IActionResult> Logs(string id)
    {
        return await Send(new ContainerLogsQuery(id));
    }

    /// <summary>
    /// Start a container
    /// </summary>
    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(string id)
    {
        return await Send(new ContainerStartCommand(id));
    }

    /// <summary>
    /// Stop a container
    /// </summary>
    [HttpPut("{id}/stop")]
    public async Task<IActionResult> Stop(string id)
    {
        return await Send(new ContainerStopCommand(id));
    }

    /// <summary>
    /// Restart a container
    /// </summary>
    [HttpPut("{id}/restart")]
    public async Task<IActionResult> Restart(string id)
    {
        return await Send(new ContainerRestartCommand(id));
    }
    
    /// <summary>
    /// Prune containers
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Prune()
    {
        return await Send(new ContainerPruneCommand());
    }
}