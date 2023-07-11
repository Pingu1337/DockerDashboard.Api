using System.Diagnostics;

namespace Infrastructure.Shell.Exceptions;

public class NonZeroExitCodeException : Exception
{
    public NonZeroExitCodeException(Process process, string command)
        : base($"Command exited with non-zero exit code.({process.ExitCode})")
    {
        Details = new NonZeroExitCodeDetails(process, command);
    }

    public NonZeroExitCodeDetails Details { get; }
}

public record NonZeroExitCodeDetails
{
    public NonZeroExitCodeDetails(Process process, string command)
    {
        ExitCode = process.ExitCode;
        Command = command;
        Error = CleanStdErr(process.StandardError.ReadToEnd());
    }

    public string Message => $"Command {Command}, exited with non-zero exit code({ExitCode}).";
    public int ExitCode { get; }
    public string Command { get; }
    public string Error { get; }

    private static string CleanStdErr(string error) => error.TrimEnd('\n').Trim();
}