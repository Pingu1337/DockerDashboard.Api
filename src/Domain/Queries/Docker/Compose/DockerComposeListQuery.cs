using Domain.Models.Docker.Compose;
using MediatR;

namespace Domain.Queries.Docker.Compose;

public record DockerComposeListQuery : IRequest<IEnumerable<DockerCompose>>
{
    public const string Command = "docker compose ls --format json";
    public const string LegacyCommand = "docker-compose ls --format json";
}