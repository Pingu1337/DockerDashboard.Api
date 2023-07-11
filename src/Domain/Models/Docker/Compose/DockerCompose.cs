namespace Domain.Models.Docker.Compose;

public record DockerCompose
{
    public string Name { get; init; }
    public string Status { get; init; }
    public string ConfigFiles { get; init; }
}