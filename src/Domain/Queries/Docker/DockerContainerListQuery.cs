using Domain.Models.Docker;
using MediatR;

namespace Domain.Queries.Docker;

public record DockerContainerListQuery : IRequest<List<DockerContainer>>
{
    public const string Command = "docker ps -a --format='{{json .}}'";
}