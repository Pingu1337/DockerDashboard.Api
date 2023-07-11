using Domain.Models.Docker;
using Domain.Models.Docker.Container;
using Infrastructure.Shell;
using MediatR;
using Newtonsoft.Json;

namespace Domain.Queries.Docker.Container;

public record ContainerInspectQuery(string Id) : IRequest<IEnumerable<DockerContainerInspect>>
{
    public string Command => $"docker inspect {Id}";
}

public class ContainerInspectQueryHandler : IRequestHandler<ContainerInspectQuery, IEnumerable<DockerContainerInspect>>
{
    public Task<IEnumerable<DockerContainerInspect>> Handle(ContainerInspectQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(request.Command).Output;

        var dockerInspect = JsonConvert.DeserializeObject<IEnumerable<DockerContainerInspect>>(output);

        return Task.FromResult(dockerInspect);
    }
}