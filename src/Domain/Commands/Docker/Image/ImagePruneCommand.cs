using Infrastructure.Shell;
using MediatR;

namespace Domain.Commands.Docker.Image;

public record ImagePruneCommand(bool All) : IRequest<string>
{
    public string Command => $"docker image prune -f {(All ? "-a" : "")}";
}

public class ImagePruneCommandHandler : IRequestHandler<ImagePruneCommand, string>
{
    public Task<string> Handle(ImagePruneCommand request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(request.Command);
        return Task.FromResult(output.Output);
    }
}