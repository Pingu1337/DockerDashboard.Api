using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker;

public record DockerRestartCommand(string Id) : IRequest<string>
{
    public string Command => $"docker restart {Id}";
}

public class DockerRestartCommandHandler : IRequestHandler<DockerRestartCommand, string>
{
    public async Task<string> Handle(DockerRestartCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}