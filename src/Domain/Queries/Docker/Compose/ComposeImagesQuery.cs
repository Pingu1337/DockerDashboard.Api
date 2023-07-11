using Domain.Models.Docker.Compose;
using Domain.Models.Docker.Image;
using Infrastructure.Shell;
using MediatR;
using Newtonsoft.Json;

namespace Domain.Queries.Docker.Compose;

public record ComposeImagesQuery(string Name) : IRequest<IEnumerable<DockerImage>>
{
    public string Command => $"docker-compose --project-name {Name} images --format json";
}

public class ComposeImagesQueryHandler
    : IRequestHandler<ComposeImagesQuery, IEnumerable<DockerImage>>
{
    public Task<IEnumerable<DockerImage>> Handle(ComposeImagesQuery request,
        CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(request.Command).Output;
        return Task.FromResult(JsonConvert.DeserializeObject<IEnumerable<DockerImage>>(output));
    }
}