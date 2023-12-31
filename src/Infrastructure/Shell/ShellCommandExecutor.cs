using System.Diagnostics;
using Infrastructure.Shell.Exceptions;
using Infrastructure.Shell.Models;

namespace Infrastructure.Shell;

public class ShellCommandExecutor
{
    public static CommandOutput ExecuteCommand(string command)
    {
        var process = new Process();
        var startInfo = new ProcessStartInfo
        {
            FileName = "bash",
            Arguments = $"-c \"{command}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        process.StartInfo = startInfo;
        process.Start();

        var output = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        if (process.ExitCode is not 0)
        {
            throw new NonZeroExitCodeException(process, command);
        }

        return new CommandOutput(output);
    }
}