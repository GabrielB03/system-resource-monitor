// Main window that displays system metrics
using System.Drawing;
using SystemResourceMonitor.Models;
using SystemResourceMonitor.Services;
using Timer = System.Windows.Forms.Timer;

namespace SystemResourceMonitor.Forms;

public partial class MainForm : Form
{
    private readonly ResourceMonitorService monitorService;
    private readonly Timer updateTimer;
    private const int UpdateInterval = 1000; // Update every second

    public MainForm()
    {
        InitializeComponent();
        monitorService = new ResourceMonitorService();

        updateTimer = new Timer();
        updateTimer.Interval = UpdateInterval;
        updateTimer.Tick += UpdateTimer_Tick;

        SetupForm();
        updateTimer.Start();
    }

    // Configure main form appearance
    private void SetupForm()
    {
        this.Text = "System Resource Monitor";
        this.Size = new Size(500, 400);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    // Time event handler to update metrics
    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
        try
        {
            var metrics = monitorService.GetMetrics();
            UpdateUI(metrics);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating metrics: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            updateTimer.Stop();
        }
    }

    // Update UI with new metrics
    private void UpdateUI(SystemMetrics metrics)
    {
        // Update CPU display
        lblCpuValue.Text = $"{metrics.CpuUsage:F1}%";
        progressBarCpu.Value = (int)Math.Min(metrics.DiskUsage, 100);

        // Update RAM display
        lblRamValue.Text = $"{metrics.RamUsage:F1}%";
        progressBarRam.Value = (int)Math.Min(metrics.RamUsage, 100);

        // Update Disk display
        lblDiskValue.Text = $"{metrics.DiskUsage:F1}%";
        progressBarDisk.Value = (int)Math.Min(metrics.DiskUsage, 100);

        // Update detailed information
        long ramAvailableGB = metrics.AvailableRam / (1024 * 1024 * 1024);
        long ramTotalGB = metrics.TotalRam / (1024 * 1024 * 1024);
        long diskAvailableGB = metrics.AvailableDiskSpace / (1024 * 1024 * 1024);
        long diskTotalGB = metrics.TotalDiskSpace / (1024 * 1024 * 1024);

        lblRamDetails.Text = $"Available RAM: {ramAvailableGB}GB of {ramTotalGB}GB";
        lblDiskDetails.Text = $"Available Disk: {diskAvailableGB}GB of {diskTotalGB}GB";
    }

    // Cleanup resources when form is closing
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        updateTimer?.Dispose();
        monitorService?.Dispose();
    }
}