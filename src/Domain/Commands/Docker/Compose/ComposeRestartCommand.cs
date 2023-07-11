using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record ComposeRestartCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} restart";
}

public class ComposeRestartCommandHandler : IRequestHandler<ComposeRestartCommand, string>
{
    public async Task<string> Handle(ComposeRestartCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}