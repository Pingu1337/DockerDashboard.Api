using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Container;

public record ContainerPruneCommand : IRequest<string>
{
    public const string Command = "docker container prune -f";
}

public class ContainerPruneCommandHandler : IRequestHandler<ContainerPruneCommand, string>
{
    public Task<string> Handle(ContainerPruneCommand request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(ContainerPruneCommand.Command);
        return Task.FromResult(output.Output);
    }
}