using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record DockerComposeStopCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} stop";
}

public class DockerComposeStopCommandHandler : IRequestHandler<DockerComposeStopCommand, string>
{
    public async Task<string> Handle(DockerComposeStopCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}