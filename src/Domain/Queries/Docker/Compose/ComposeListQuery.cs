using Domain.Models.Docker.Compose;
using Infrastructure.Shell;
using MediatR;
using Newtonsoft.Json;

namespace Domain.Queries.Docker.Compose;

public record ComposeListQuery : IRequest<IEnumerable<DockerCompose>>
{
    public const string Command = "docker-compose ls --format json";
}

public class ComposeListQueryHandler : IRequestHandler<ComposeListQuery, IEnumerable<DockerCompose>>
{
    public Task<IEnumerable<DockerCompose>> Handle(ComposeListQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(ComposeListQuery.Command).Output;
        return Task.FromResult(JsonConvert.DeserializeObject<IEnumerable<DockerCompose>>(output));
    }
}