using Domain.Models.Docker;
using Infrastructure.Shell;
using MediatR;
using Newtonsoft.Json;

namespace Domain.Queries.Docker;

public record ContainerInspectQuery(string Id) : IRequest<IEnumerable<DockerInspect>>
{
    public string Command => $"docker inspect {Id}";
}

public class ContainerInspectQueryHandler : IRequestHandler<ContainerInspectQuery, IEnumerable<DockerInspect>>
{
    public Task<IEnumerable<DockerInspect>> Handle(ContainerInspectQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(request.Command);

        var dockerInspect = JsonConvert.DeserializeObject<IEnumerable<DockerInspect>>(output);

        return Task.FromResult(dockerInspect);
    }
}