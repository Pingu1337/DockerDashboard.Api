using Domain.Models.Docker;
using Domain.Queries.Docker;
using Infrastructure.Shell;
using MediatR;
using Newtonsoft.Json;

namespace Domain.Handlers.Docker;

public class DockerInspectQueryHandler : IRequestHandler<DockerInspectQuery, IEnumerable<DockerInspect>>
{
    public Task<IEnumerable<DockerInspect>> Handle(DockerInspectQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(request.Command);

        var dockerInspect = JsonConvert.DeserializeObject<IEnumerable<DockerInspect>>(output);

        return Task.FromResult(dockerInspect);
    }
}