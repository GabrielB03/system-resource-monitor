// Model class that holds system resource metrics data
// Including CPU, RAM and Disk usage statistics
namespace SystemResourceMonitor.Models;

public class SystemMetrics
{
    // CPU usage percentage
    public float CpuUsage { get; set; }

    // RAM usage percentage
    public float RamUsage { get; set; }

    // Disk usage percentage
    public float DiskUsage { get; set; }

    // Total RAM in bytes
    public long TotalRam { get; set; }

    // Available RAM in bytes
    public long AvailableRam { get; set; }

    // Total disk space in bytes
    public long TotalDiskSpace { get; set; }

    // Available disk space in bytes
    public long AvailableDiskSpace { get; set; }

    // Timestamp when metrics were collected
    public DateTime Timestamp { get; set; }

    public SystemMetrics()
    {
        Timestamp = DateTime.Now;
    }
}