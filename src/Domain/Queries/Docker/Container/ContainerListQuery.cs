using Domain.Extensions;
using Domain.Models.Docker.Container;
using Infrastructure.Shell;
using MediatR;

namespace Domain.Queries.Docker.Container;

public record ContainerListQuery : IRequest<IEnumerable<DockerContainer>>
{
    public const string Command = "docker ps -a --format='{{json .}}'";
}

public class ContainerListQueryHandler : IRequestHandler<ContainerListQuery, IEnumerable<DockerContainer>>
{
    public Task<IEnumerable<DockerContainer>> Handle(ContainerListQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(ContainerListQuery.Command);
        return Task.FromResult(output.ParseContainers());
    }
}