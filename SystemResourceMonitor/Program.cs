// Main entry point for the application
// Initializes Windows Forms configuration and starts the main form
using SystemResourceMonitor.Forms;

namespace SystemResourceMonitor;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}