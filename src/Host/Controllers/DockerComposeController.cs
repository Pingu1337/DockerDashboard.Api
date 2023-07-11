using Domain.Queries.Docker.Compose;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

public class DockerComposeController : ControllerBase
{
    public DockerComposeController(IMediator mediator) : base(mediator)
    {
    }
    
    /// <summary>
    /// List running compose projects
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> List()
    {
        return await Send(new DockerComposeListQuery());
    }
}