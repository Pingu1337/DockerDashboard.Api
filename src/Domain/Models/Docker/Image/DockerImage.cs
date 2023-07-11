using Newtonsoft.Json;

namespace Domain.Models.Docker.Image;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public record DockerImage
{
    public string Id { get; init; }
    public string ContainerName { get; init; }
    public string Repository { get; init; }
    public string Tag { get; init; }
    public string CreatedAt { get; init; }
    public string Size { get; init; }
}