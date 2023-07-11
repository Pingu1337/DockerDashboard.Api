using MediatR;

namespace Domain.Commands.Docker;

public record DockerStopCommand(string Id) : IRequest<string>
{
    public string Command => $"docker stop {Id}";
}