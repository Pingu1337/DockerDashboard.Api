using MediatR;

namespace Domain.Commands.Docker;

public record DockerRestartCommand(string Id) : IRequest<string>
{
    public string Command => $"docker restart {Id}";
}