using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker;

public record ContainerRestartCommand(string Id) : IRequest<string>
{
    public string Command => $"docker restart {Id}";
}

public class ContainerRestartCommandHandler : IRequestHandler<ContainerRestartCommand, string>
{
    public Task<string> Handle(ContainerRestartCommand request, CancellationToken cancellationToken)
    {
        ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult($"container {request.Id} restarted");
    }
}