using System.Configuration;
using System.Data;
using System.Windows;
using Application = System.Windows.Application;
using Forms = System.Windows.Forms;

namespace conscience
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private TrayManager _trayManager;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();

            _trayManager = new TrayManager(mainWindow);
            _trayManager.ShowNotification("Conscience", "Be sure to do your work today!", ToolTipIcon.Warning);
            SteamMonitor.StartMonitoring(_trayManager);

        }

        protected override void OnExit(ExitEventArgs e)
        {
            _trayManager?.Dispose();
            base.OnExit(e);
        }
    }

}
