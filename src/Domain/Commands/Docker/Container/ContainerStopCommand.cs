using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Container;

public record ContainerStopCommand(string Id) : IRequest<string>
{
    public string Command => $"docker stop {Id}";
}

public class ContainerStopCommandHandler : IRequestHandler<ContainerStopCommand, string>
{
    public Task<string> Handle(ContainerStopCommand request, CancellationToken cancellationToken)
    {
        ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult($"container {request.Id} stopped");
    }
}