using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker;

public record DockerStopCommand(string Id) : IRequest<string>
{
    public string Command => $"docker stop {Id}";
}

public class DockerStopCommandHandler : IRequestHandler<DockerStopCommand, string>
{
    public async Task<string> Handle(DockerStopCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}