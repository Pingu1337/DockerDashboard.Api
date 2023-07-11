using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker;

public record ContainerRestartCommand(string Id) : IRequest<string>
{
    public string Command => $"docker restart {Id}";
}

public class ContainerRestartCommandHandler : IRequestHandler<ContainerRestartCommand, string>
{
    public async Task<string> Handle(ContainerRestartCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}