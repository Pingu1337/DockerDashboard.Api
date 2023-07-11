using Domain.Queries.Docker.Image;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    public ImageController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// List all images
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return await Send(new ImageListQuery());
    }
}