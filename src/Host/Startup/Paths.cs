using System.Reflection;

namespace Host.Startup;

public static class Paths
{
    public static string XmlCommentsFilePath =>
        Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml");
}