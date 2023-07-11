using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record ComposeStopCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} stop";
}

public class ComposeStopCommandHandler : IRequestHandler<ComposeStopCommand, string>
{
    public Task<string> Handle(ComposeStopCommand request, CancellationToken cancellationToken)
    {
        ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult($"{request.Name} stopped");
    }
}