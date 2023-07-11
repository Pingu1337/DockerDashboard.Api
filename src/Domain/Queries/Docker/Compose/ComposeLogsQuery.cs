using System.Text.RegularExpressions;
using Infrastructure.Shell;
using MediatR;

namespace Domain.Queries.Docker.Compose;

public record ComposeLogsQuery(string Name) : IRequest<string[]>
{
    public string Command => $"docker-compose --project-name {Name} logs";
}

public partial class ComposeLogsQueryHandler : IRequestHandler<ComposeLogsQuery, string[]>
{
    public async Task<string[]> Handle(ComposeLogsQuery request, CancellationToken cancellationToken)
    {
        var output = ShellCommandExecutor.ExecuteCommand(request.Command);
        return await Task.FromResult(TrimmedLogs(output));
    }

    private static string[] TrimmedLogs(string output) => output.Split("\n")
        .Select(log => ClearWhitespace().Replace(log.TrimStart(), " "))
        .ToArray();

    [GeneratedRegex(@"\s+")]
    private static partial Regex ClearWhitespace();
}