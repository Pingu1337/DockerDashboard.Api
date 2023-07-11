using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker;

public record ContainerStartCommand(string Id) : IRequest<string>
{
    public string Command => $"docker start {Id}";
}

public class ContainerStartCommandHandler : IRequestHandler<ContainerStartCommand, string>
{
    public async Task<string> Handle(ContainerStartCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}