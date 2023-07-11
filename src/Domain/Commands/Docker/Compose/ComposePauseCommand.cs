using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Compose;

public record ComposePauseCommand(string Name) : IRequest<string>
{
    public string Command => $"docker-compose --project-name {Name} pause";
}

public class ComposePauseCommandHandler : IRequestHandler<ComposePauseCommand, string>
{
    public async Task<string> Handle(ComposePauseCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(ShellCommandExecutor.ExecuteCommand(request.Command));
    }
}