using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record ComposeUnpauseCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} unpause";
}

public class ComposeUnpauseCommandHandler : IRequestHandler<ComposeUnpauseCommand, string>
{
    public async Task<string> Handle(ComposeUnpauseCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}