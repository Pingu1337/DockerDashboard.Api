using Domain.Models.Docker;
using Infrastructure.Shell;
using MediatR;
using Newtonsoft.Json;

namespace Domain.Queries.Docker;

public record DockerContainerListQuery : IRequest<List<DockerContainer>>
{
    public const string Command = "docker ps -a --format='{{json .}}'";
}

public class DockerContainerListQueryHandler : IRequestHandler<DockerContainerListQuery, List<DockerContainer>>
{
    public Task<List<DockerContainer>> Handle(DockerContainerListQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(DockerContainerListQuery.Command);
        return Task.FromResult(ParseOutput(output));
    }

    private static List<DockerContainer> ParseOutput(string output)
    {
        var json = CreateJson(output);
        return JsonConvert.DeserializeObject<List<DockerContainer>>(json);
    }

    private static string CreateJson(string input)
    {
        var json = input.Replace("}", "},");
        return $"[{json.TrimEnd(',')}]";
    }
}