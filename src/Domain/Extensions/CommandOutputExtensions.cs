using Domain.Models.Docker.Container;
using Domain.Models.Docker.Image;
using Infrastructure.Shell.Models;

namespace Domain.Extensions;

public static class CommandOutputExtensions
{
    public static IEnumerable<DockerContainer> ParseContainers(this CommandOutput commandOutput)
    {
        var json = CreateJson(commandOutput.Output);

        return json.Deserialize<IEnumerable<DockerContainer>>();
    }

    public static IEnumerable<DockerImage> ParseImages(this CommandOutput commandOutput)
    {
        var json = CreateJson(commandOutput.Output);

        return json.Deserialize<IEnumerable<DockerImage>>();
    }

    private static string CreateJson(string input)
    {
        var json = input.Replace("}", "},");
        return $"[{json.TrimEnd(',')}]";
    }
}