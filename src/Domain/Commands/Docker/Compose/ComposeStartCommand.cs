using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record ComposeStartCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} start";
}

public class ComposeStartCommandHandler : IRequestHandler<ComposeStartCommand, string>
{
    public Task<string> Handle(ComposeStartCommand request, CancellationToken cancellationToken)
    {
        ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult($"{request.Name} started");
    }
}