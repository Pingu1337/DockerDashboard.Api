using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker;

public record ContainerStopCommand(string Id) : IRequest<string>
{
    public string Command => $"docker stop {Id}";
}

public class ContainerStopCommandHandler : IRequestHandler<ContainerStopCommand, string>
{
    public async Task<string> Handle(ContainerStopCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}