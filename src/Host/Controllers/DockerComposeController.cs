using Domain.Commands.Docker.Compose;
using Domain.Queries.Docker.Compose;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("[controller]")]
public class DockerComposeController : ControllerBase
{
    public DockerComposeController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// List running compose projects
    /// </summary>
    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        return await Send(new DockerComposeListQuery());
    }

    /// <summary>
    /// List images in a compose project
    /// </summary>
    [HttpGet("{name}/images")]
    public async Task<IActionResult> GetImages(string name)
    {
        return await Send(new DockerComposeImagesQuery(name));
    }

    /// <summary>
    /// Stop a compose project
    /// </summary>
    [HttpPut("{name}/stop")]
    public async Task<IActionResult> Stop(string name)
    {
        return await Send(new DockerComposeStopCommand(name));
    }

    /// <summary>
    /// Start a compose project
    /// </summary>
    [HttpPut("{name}/start")]
    public async Task<IActionResult> Start(string name)
    {
        return await Send(new DockerComposeStartCommand(name));
    }

    /// <summary>
    /// Restart a compose project
    /// </summary>
    [HttpPut("{name}/restart")]
    public async Task<IActionResult> Restart(string name)
    {
        return await Send(new DockerComposeRestartCommand(name));
    }

    /// <summary>
    /// Pause a compose project
    /// </summary>
    [HttpPut("{name}/pause")]
    public async Task<IActionResult> Pause(string name)
    {
        return await Send(new DockerComposePauseCommand(name));
    }

    /// <summary>
    /// Unpause a compose project
    /// </summary>
    [HttpPut("{name}/unpause")]
    public async Task<IActionResult> Unpause(string name)
    {
        return await Send(new DockerComposeUnpauseCommand(name));
    }
}