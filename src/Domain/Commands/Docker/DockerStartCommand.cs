using MediatR;

namespace Domain.Commands.Docker;

public record DockerStartCommand(string Id) : IRequest<string>
{
    public string Command => $"docker start {Id}";
}