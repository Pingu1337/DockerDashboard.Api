using Domain.Models.Attributes;
using Newtonsoft.Json;

namespace Domain.Models.Docker;

public record DockerContainer
{
    [JsonConverter(typeof(UnescapeCommandConverter))]
    public string Command { get; init; }

    [JsonConverter(typeof(DockerDateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    public string Id { get; init; }
    public string Image { get; init; }
    public string Labels { get; init; }
    public string LocalVolumes { get; init; }
    public string Mounts { get; init; }
    public string Names { get; init; }
    public string Networks { get; init; }
    public string Ports { get; init; }
    public string RunningFor { get; init; }
    public string Size { get; init; }
    public string State { get; init; }
    public string Status { get; init; }
}