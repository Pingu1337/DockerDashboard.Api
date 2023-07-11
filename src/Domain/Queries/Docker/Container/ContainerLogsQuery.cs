using Infrastructure.Shell;
using MediatR;

namespace Domain.Queries.Docker.Container;

public record ContainerLogsQuery(string Id) : IRequest<string[]>
{
    public string Command => $"docker logs {Id}";
}

public class ContainerLogsQueryHandler : IRequestHandler<ContainerLogsQuery, string[]>
{
    public async Task<string[]> Handle(ContainerLogsQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command).Output.Split("\n"));
    }
}