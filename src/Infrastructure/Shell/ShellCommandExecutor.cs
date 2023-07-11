using System.Diagnostics;

namespace Infrastructure.Shell;

public class ShellCommandExecutor
{
    public static string ExecuteCommand(string command)
    {
        var process = new Process();
        var startInfo = new ProcessStartInfo
        {
            FileName = "bash", // or "cmd" for Windows
            Arguments = $"-c \"{command}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        process.StartInfo = startInfo;
        process.Start();

        var output = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        return output;
    }
}