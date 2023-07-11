using Domain.Models.Docker.Container;
using Domain.Models.Docker.Image;
using Infrastructure.Shell.Models;
using Newtonsoft.Json;

namespace Domain.Extensions;

public static class CommandOutputExtensions
{
    public static IEnumerable<DockerContainer> ParseContainers(this CommandOutput commandOutput)
    {
        var json = CreateJson(commandOutput.Output);
        return JsonConvert.DeserializeObject<IEnumerable<DockerContainer>>(json);
    }

    public static IEnumerable<DockerImage> ParseImages(this CommandOutput commandOutput)
    {
        var json = CreateJson(commandOutput.Output);
        return JsonConvert.DeserializeObject<IEnumerable<DockerImage>>(json);
    }

    private static string CreateJson(string input)
    {
        var json = input.Replace("}", "},");
        return $"[{json.TrimEnd(',')}]";
    }
}