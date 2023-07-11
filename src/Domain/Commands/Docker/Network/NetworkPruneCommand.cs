using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Network;

public class NetworkPruneCommand : IRequest<string>
{
    public const string Command = "docker network prune -f";
}

public class NetworkPruneCommandHandler : IRequestHandler<NetworkPruneCommand, string>
{
    public Task<string> Handle(NetworkPruneCommand request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(NetworkPruneCommand.Command);
        return Task.FromResult(output.Output);
    }
}