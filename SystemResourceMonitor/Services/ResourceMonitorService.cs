using System.Diagnostics;
using SystemResourceMonitor.Models;

namespace SystemResourceMonitor.Services;

public class ResourceMonitorService : IDisposable
{
    // Performance counters for monitoring system resources
    private readonly PerformanceCounter cpuCounter;
    private readonly PerformanceCounter ramCounter;
    private readonly List<SystemMetrics> metricsHistory;

    // Maximum number of history items to keep (1 minute of data)
    private const int MAX_HISTORY_ITEMS = 60;

    public ResourceMonitorService()
    {
        // Initialize performance counters
        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
        ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use", true);
        metricsHistory = new List<SystemMetrics>();

        // First read to initialize counters
        cpuCounter.NextValue();
        ramCounter.NextValue();
    }

    public SystemMetrics GetMetrics()
    {
        var metrics = new SystemMetrics
        {
            CpuUsage = cpuCounter.NextValue(),
            RamUsage = ramCounter.NextValue()
        };

        try
        {
            DriveInfo drive = new DriveInfo("C");
            metrics.DiskUsage = (float)(100.0 * (drive.TotalSize - drive.AvailableFreeSpace) / drive.TotalSize);
            metrics.TotalDiskSpace = drive.TotalSize;
            metrics.AvailableDiskSpace = drive.AvailableFreeSpace;
        }
        catch (Exception ex)
        {
            metrics.DiskUsage = 0;
            metrics.TotalDiskSpace = 0;
            metrics.AvailableDiskSpace = 0;
        }

        // Add to history and maintain maximum size
        metricsHistory.Add(metrics);
        if (metricsHistory.Count > MAX_HISTORY_ITEMS)
            metricsHistory.RemoveAt(0);

        return metrics;
    }

    public List<SystemMetrics> GetHistory()
    {
        return new List<SystemMetrics>(metricsHistory);
    }

    public void Dispose()
    {
        cpuCounter?.Dispose();
        ramCounter?.Dispose();
        GC.SuppressFinalize(this);
    }
}