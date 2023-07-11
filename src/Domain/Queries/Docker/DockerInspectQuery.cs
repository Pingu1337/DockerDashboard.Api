using Domain.Models.Docker;
using MediatR;

namespace Domain.Queries.Docker;

public record DockerInspectQuery(string Id) : IRequest<IEnumerable<DockerInspect>>
{
    public string Command => $"docker inspect {Id}";
}