using Domain.Commands.Docker;
using Infrastructure.Shell;
using MediatR;

namespace Domain.Handlers.Docker;

public class DockerStopCommandHandler : IRequestHandler<DockerStopCommand, string>
{
    public Task<string> Handle(DockerStopCommand request, CancellationToken cancellationToken)
    {
        ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult($"Container {request.Id} stopped");
    }
}