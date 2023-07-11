using Domain.Extensions;
using Domain.Models.Docker.Image;
using Infrastructure.Shell;
using MediatR;

namespace Domain.Queries.Docker.Image;

public record ImageListQuery() : IRequest<IEnumerable<DockerImage>>
{
    public const string Command = "docker images --format='{{json .}}'";
}

public class ImageListQueryHandler : IRequestHandler<ImageListQuery, IEnumerable<DockerImage>>
{
    public Task<IEnumerable<DockerImage>> Handle(ImageListQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(ImageListQuery.Command);
        return Task.FromResult(output.ParseImages());
    }
}