using Domain.Commands.Docker;
using Infrastructure.Shell;
using MediatR;

namespace Domain.Handlers.Docker;

public class DockerRestartCommandHandler : IRequestHandler<DockerRestartCommand, string>
{
    public Task<string> Handle(DockerRestartCommand request, CancellationToken cancellationToken)
    {
        ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult($"Container {request.Id} restarted");
    }
}