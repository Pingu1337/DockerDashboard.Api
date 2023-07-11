using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record DockerComposeRestartCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} restart";
}

public class DockerComposeRestartCommandHandler : IRequestHandler<DockerComposeRestartCommand, string>
{
    public async Task<string> Handle(DockerComposeRestartCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}