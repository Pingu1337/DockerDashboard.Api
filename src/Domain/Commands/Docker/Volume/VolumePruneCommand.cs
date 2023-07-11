using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Volume;

public record VolumePruneCommand(bool All) : IRequest<string>
{
    public string Command => $"docker volume prune -f {(All ? "-a" : "")}";
}

public class VolumePruneCommandHandler : IRequestHandler<VolumePruneCommand, string>
{
    public Task<string> Handle(VolumePruneCommand request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult(output.Output);
    }
}