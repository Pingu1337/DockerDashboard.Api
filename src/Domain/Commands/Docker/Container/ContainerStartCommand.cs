using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Container;

public record ContainerStartCommand(string Id) : IRequest<string>
{
    public string Command => $"docker start {Id}";
}

public class ContainerStartCommandHandler : IRequestHandler<ContainerStartCommand, string>
{
    public Task<string> Handle(ContainerStartCommand request, CancellationToken cancellationToken)
    {
        ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult($"container {request.Id} started");
    }
}