// Designer code for the main form
// Handles the initialization and layout of UI components
namespace SystemResourceMonitor.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblCpu;
    private Label lblCpuValue;
    private ProgressBar progressBarCpu;
    private Label lblRam;
    private Label lblRamValue;
    private ProgressBar progressBarRam;
    private Label lblDisk;
    private Label lblDiskValue;
    private ProgressBar progressBarDisk;
    private Label lblRamDetails;
    private Label lblDiskDetails;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    // Initialize form components and layout
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        // Initialize CPU components
        lblCpu = new Label
        {
            Location = new Point(20, 20),
            Size = new Size(100, 23),
            Text = "CPU:"
        };

        lblCpuValue = new Label
        {
            Location = new Point(400, 20),
            Size = new Size(70, 23),
            Text = "0%",
            TextAlign = ContentAlignment.MiddleRight
        };

        progressBarCpu = new ProgressBar
        {
            Location = new Point(20, 45),
            Size = new Size(450, 23)
        };

        // Initialize RAM components
        lblRam = new Label
        {
            Location = new Point(20, 90),
            Size = new Size(100, 23),
            Text = "RAM Memory:"
        };

        lblRamValue = new Label
        {
            Location = new Point(400, 90),
            Size = new Size(70, 23),
            Text = "0%",
            TextAlign = ContentAlignment.MiddleRight
        };

        progressBarRam = new ProgressBar
        {
            Location = new Point(20, 115),
            Size = new Size(450, 23)
        };

        lblRamDetails = new Label
        {
            Location = new Point(20, 140),
            Size = new Size(450, 23),
            Text = "Available RAM: 0GB of 0GB"
        };

        // Initialize Disk components
        lblDisk = new Label
        {
            Location = new Point(20, 180),
            Size = new Size(100, 23),
            Text = "Disk:"
        };

        lblDiskValue = new Label
        {
            Location = new Point(400, 180),
            Size = new Size(70, 23),
            Text = "0%",
            TextAlign = ContentAlignment.MiddleRight
        };

        progressBarDisk = new ProgressBar
        {
            Location = new Point(20, 205),
            Size = new Size(450, 23)
        };

        lblDiskDetails = new Label
        {
            Location = new Point(20, 230),
            Size = new Size(450, 23),
            Text = "Available Disk: 0GB of 0GB"
        };

        // Add all controls to form
        Controls.AddRange(new Control[] {
            lblCpu, lblCpuValue, progressBarCpu,
            lblRam, lblRamValue, progressBarRam, lblRamDetails,
            lblDisk, lblDiskValue, progressBarDisk, lblDiskDetails
        });
    }
}