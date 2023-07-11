using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record DockerComposeUnpauseCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} unpause";
}

public class DockerComposeUnpauseCommandHandler : IRequestHandler<DockerComposeUnpauseCommand, string>
{
    public async Task<string> Handle(DockerComposeUnpauseCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}