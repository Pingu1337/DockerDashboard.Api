using Domain.Models.Docker.Compose;
using Infrastructure.Shell;
using MediatR;
using Newtonsoft.Json;

namespace Domain.Queries.Docker.Compose;

public record DockerComposeImagesQuery(string Name) : IRequest<IEnumerable<DockerComposeImage>>
{
    public string Command => $"docker-compose --project-name {Name} images --format json";
}

public class DockerComposeImagesQueryHandler
    : IRequestHandler<DockerComposeImagesQuery, IEnumerable<DockerComposeImage>>
{
    public Task<IEnumerable<DockerComposeImage>> Handle(DockerComposeImagesQuery request,
        CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult(JsonConvert.DeserializeObject<IEnumerable<DockerComposeImage>>(output));
    }
}