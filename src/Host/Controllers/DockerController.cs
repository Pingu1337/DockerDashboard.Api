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
        var result = await Mediator.Send(new DockerContainerListQuery());
        return Ok(result);
    }

    /// <summary>
    /// Inspect a container
    /// </summary>
    /// <returns>Detailed information about the container with the specified id</returns>
    [HttpGet("inspect/{id}")]
    public async Task<IActionResult> Inspect(string id)
    {
        var result = await Mediator.Send(new DockerInspectQuery(id));
        return Ok(result);
    }
}