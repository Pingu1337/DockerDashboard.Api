using System.Text.Json.Serialization;

namespace Domain.Models.Docker;

public record DockerInspect
{
    public string Id { get; init; }
    public DateTimeOffset Created { get; init; }
    public string Path { get; init; }
    public string[] Args { get; init; }
    public DockerInspectState State { get; init; }
    public string Image { get; init; }
    public string ResolvConfPath { get; init; }
    public string HostnamePath { get; init; }
    public string HostsPath { get; init; }
    public string LogPath { get; init; }
    public string Name { get; init; }
    public int RestartCount { get; init; }
    public string Driver { get; init; }
    public string Platform { get; init; }
    public string MountLabel { get; init; }
    public string ProcessLabel { get; init; }
    public string AppArmorProfile { get; init; }
    public string[] ExecIDs { get; init; }
    public DockerInspectHostConfig HostConfig { get; init; }
    public DockerInspectGraphDriver GraphDriver { get; init; }
    public DockerInspectMount[] Mounts { get; init; }
    public DockerInspectConfig Config { get; init; }

    public DockerInspectNetworkSettings NetworkSettings { get; init; }
}

public record DockerInspectState
{
    public string Status { get; init; }
    public bool Running { get; init; }
    public bool Paused { get; init; }
    public bool Restarting { get; init; }
    public bool OomKilled { get; init; }
    public bool Dead { get; init; }
    public int Pid { get; init; }
    public int ExitCode { get; init; }
    public string Error { get; init; }
    public DateTimeOffset StartedAt { get; init; }

    public DateTimeOffset FinishedAt { get; init; }
}

public record DockerInspectHostConfig
{
    public string[] Binds { get; init; }
    public string ContainerIdFile { get; init; }
    public DockerInspectLogConfig LogConfig { get; init; }
    public string NetworkMode { get; init; }
    public Dictionary<string, List<DockerInspectPortBinding>> PortBindings { get; init; }
    public DockerInspectRestartPolicy RestartPolicy { get; init; }
    public bool AutoRemove { get; init; }
    public string VolumeDriver { get; init; }
    public string[] VolumesFrom { get; init; }
    public int[] ConsoleSize { get; init; }
    public string[] CapAdd { get; init; }
    public string[] CapDrop { get; init; }
    public string CgroupnsMode { get; init; }
    public string[] Dns { get; init; }
    public string[] DnsOptions { get; init; }
    public string[] DnsSearch { get; init; }
    public string[] ExtraHosts { get; init; }
    public string[] GroupAdd { get; init; }
    public string IpcMode { get; init; }
    public string CGroup { get; init; }
    public string[] Links { get; init; }
    public int OomScoreAdj { get; init; }
    public string PidMode { get; init; }
    public bool Privileged { get; init; }
    public bool PublishAllPorts { get; init; }
    public bool ReadonlyRootfs { get; init; }
    public string[] SecurityOpt { get; init; }
    public string UtsMode { get; init; }
    public string UsernsMode { get; init; }
    public long ShmSize { get; init; }
    public string Runtime { get; init; }
    public string Isolation { get; init; }
    public long CpuShares { get; init; }
    public long Memory { get; init; }
    public long NanoCpus { get; init; }
    public string CgroupParent { get; init; }
    public long BlkioWeight { get; init; }
    public DockerInspectBlkioWeightDevice[] BlkioWeightDevice { get; init; }
    public DockerInspectBlkioDevice[] BlkioDeviceReadBps { get; init; }
    public DockerInspectBlkioDevice[] BlkioDeviceWriteBps { get; init; }
    public DockerInspectBlkioDevice[] BlkioDeviceReadIOps { get; init; }
    public DockerInspectBlkioDevice[] BlkioDeviceWriteIOps { get; init; }
    public long CpuPeriod { get; init; }
    public long CpuQuota { get; init; }
    public long CpuRealtimePeriod { get; init; }
    public long CpuRealtimeRuntime { get; init; }
    public string CpusetCpus { get; init; }
    public string CpusetMems { get; init; }
    public DockerInspectDevice[] Devices { get; init; }
    public string[] DeviceCgroupRules { get; init; }
    public DockerInspectDeviceRequest[] DeviceRequests { get; init; }
    public long MemoryReservation { get; init; }
    public long MemorySwap { get; init; }
    public int? MemorySwappiness { get; init; }
    public bool? OomKillDisable { get; init; }
    public int? PidsLimit { get; init; }
    public DockerInspectULimit[] ULimits { get; init; }
    public long CpuCount { get; init; }
    public long CpuPercent { get; init; }
    public long IoMaximumIOps { get; init; }
    public long IoMaximumBandwidth { get; init; }
    public string[] MaskedPaths { get; init; }

    public string[] ReadonlyPaths { get; init; }
}

public record DockerInspectLogConfig
{
    public string Type { get; init; }

    public Dictionary<string, string> Config { get; init; }
}

public record DockerInspectPortBinding
{
    public string HostIp { get; init; }

    public string HostPort { get; init; }
}

public record DockerInspectRestartPolicy
{
    public string Name { get; init; }

    public int MaximumRetryCount { get; init; }
}

public record DockerInspectGraphDriver
{
    public DockerInspectGraphDriverData Data { get; init; }

    public string Name { get; init; }
}

public record DockerInspectGraphDriverData
{
    public string LowerDir { get; init; }
    public string MergedDir { get; init; }
    public string UpperDir { get; init; }

    public string WorkDir { get; init; }
}

public record DockerInspectMount
{
    public string Name { get; init; }
    public string Source { get; init; }
    public string Destination { get; init; }
    public string Driver { get; init; }
    public string Mode { get; init; }
    public bool Rw { get; init; }
}

public record DockerInspectConfig
{
    public string Hostname { get; init; }
    public string DomainName { get; init; }
    public string User { get; init; }
    public bool AttachStdin { get; init; }
    public bool AttachStdout { get; init; }
    public bool AttachStderr { get; init; }
    public Dictionary<string, object> ExposedPorts { get; init; }
    public bool Tty { get; init; }
    public bool OpenStdin { get; init; }
    public bool StdinOnce { get; init; }
    public string[] Env { get; init; }
    public string[] Cmd { get; init; }
    public string Image { get; init; }
    public Dictionary<string, object> Volumes { get; init; }
    public string WorkingDir { get; init; }
    public string[] Entrypoint { get; init; }
    public string[] OnBuild { get; init; }

    public Dictionary<string, string> Labels { get; init; }
}

public record DockerInspectNetworkSettings
{
    public string Bridge { get; init; }
    public string SandboxId { get; init; }
    public bool HairpinMode { get; init; }
    public string LinkLocalIPv6Address { get; init; }
    public int LinkLocalIPv6PrefixLen { get; init; }
    public Dictionary<string, DockerInspectPort[]> Ports { get; init; }
    public string SandboxKey { get; init; }
    public DockerInspectSecondaryIp[] SecondaryIpAddresses { get; init; }
    public DockerInspectSecondaryIp[] SecondaryIPv6Addresses { get; init; }
    public string EndpointId { get; init; }
    public string Gateway { get; init; }
    public string GlobalIPv6Address { get; init; }
    public int GlobalIPv6PrefixLen { get; init; }
    public string IpAddress { get; init; }
    public int IpPrefixLen { get; init; }
    [JsonPropertyName("IPv6Gateway")] public string Ipv6Gateway { get; init; }
    public string MacAddress { get; init; }

    public Dictionary<string, DockerInspectNetwork> Networks { get; init; }
}

public record DockerInspectPort
{
    public string HostIp { get; init; }

    public string HostPort { get; init; }
}

public record DockerInspectSecondaryIp
{
    public string Address { get; init; }

    public int PrefixLen { get; init; }
}

public record DockerInspectNetwork
{
    public DockerInspectIpamConfig IpamConfig { get; init; }
    public string[] Links { get; init; }
    public string[] Aliases { get; init; }
    public string NetworkId { get; init; }
    public string EndpointId { get; init; }
    public string Gateway { get; init; }
    public string IpAddress { get; init; }
    public int IpPrefixLen { get; init; }
    [JsonPropertyName("IPv6Gateway")] public string Ipv6Gateway { get; init; }
    public string GlobalIPv6Address { get; init; }
    public int GlobalIPv6PrefixLen { get; init; }
    public string MacAddress { get; init; }

    public Dictionary<string, string> DriverOpts { get; init; }
}

public class DockerInspectIpamConfig : Dictionary<string, object>
{
    // TODO: Add properties for IPAM configuration
}

public class DockerInspectBlkioWeightDevice : Dictionary<string, object>
{
    // TODO: Add properties for Blkio weight device
}

public class DockerInspectBlkioDevice : Dictionary<string, object>
{
    // TODO: Add properties for Blkio device
}

public class DockerInspectDevice : Dictionary<string, object>
{
    // TODO: Add properties for device details
}

public class DockerInspectDeviceRequest : Dictionary<string, object>
{
    // TODO: Add properties for device request
}

public class DockerInspectULimit : Dictionary<string, object>
{
    // TODO: Add properties for u-limit details
}