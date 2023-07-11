namespace Domain.Models.Docker.Compose;

public record DockerComposeImage
{
    public string Id { get; init; }
    public string ContainerName { get; init; }
    public string Repository { get; init; }
    public string Tag { get; init; }
    public long Size { get; init; }
}