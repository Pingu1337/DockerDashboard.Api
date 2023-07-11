using Domain.Commands.Docker;
using Infrastructure.Shell;
using MediatR;

namespace Domain.Handlers.Docker;

public class DockerStartCommandHandler : IRequestHandler<DockerStartCommand, string>
{
    public Task<string> Handle(DockerStartCommand request, CancellationToken cancellationToken)
    {
        ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult($"Container {request.Id} started");
    }
}