using Domain.Models.Docker.Compose;
using Infrastructure.Shell;
using MediatR;
using Newtonsoft.Json;

namespace Domain.Queries.Docker.Compose;

public record DockerComposeListQuery : IRequest<IEnumerable<DockerCompose>>
{
    public const string Command = "docker-compose ls --format json";
}

public class DockerComposeListQueryHandler : IRequestHandler<DockerComposeListQuery, IEnumerable<DockerCompose>>
{
    public Task<IEnumerable<DockerCompose>> Handle(DockerComposeListQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(DockerComposeListQuery.Command);
        return Task.FromResult(JsonConvert.DeserializeObject<IEnumerable<DockerCompose>>(output));
    }
}