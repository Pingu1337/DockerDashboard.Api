using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record DockerComposeStartCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} start";
}

public class DockerComposeStartCommandHandler : IRequestHandler<DockerComposeStartCommand, string>
{
    public async Task<string> Handle(DockerComposeStartCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}