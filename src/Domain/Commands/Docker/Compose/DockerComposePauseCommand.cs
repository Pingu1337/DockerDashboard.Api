using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record DockerComposePauseCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} pause";
}

public class DockerComposePauseCommandHandler : IRequestHandler<DockerComposePauseCommand, string>
{
    public async Task<string> Handle(DockerComposePauseCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}