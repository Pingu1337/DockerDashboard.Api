using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker;

public record DockerStartCommand(string Id) : IRequest<string>
{
    public string Command => $"docker start {Id}";
}

public class DockerStartCommandHandler : IRequestHandler<DockerStartCommand, string>
{
    public async Task<string> Handle(DockerStartCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}