namespace Domain.Models.Docker.Image;

public record DockerImage
{
    public string Id { get; init; }
    public string ContainerName { get; init; }
    public string Repository { get; init; }
    public string Tag { get; init; }
    public long Size { get; init; }
}