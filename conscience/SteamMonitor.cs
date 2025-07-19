using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conscience
{
    public static class SteamMonitor
    {
        private static System.Timers.Timer _blockTimer;
        private static System.Timers.Timer _notifyTimer;

        public static void StartMonitoring(TrayManager trayManager)
        {
            _blockTimer = new System.Timers.Timer(300000);
            _notifyTimer = new System.Timers.Timer(1800000);

            _blockTimer.Elapsed += (s, e) =>
            {
                if (IsSteamRunning())
                {
                    KillSteam();
                    trayManager.ShowNotification("Conscience alert!", "Steam process was killed! You must do your work!", ToolTipIcon.Error);
                }
            };
            _notifyTimer.Elapsed += (s, e) =>
            {
                trayManager.ShowNotification("Conscience alert!", "Do your work!", ToolTipIcon.Warning);
            };

            _blockTimer.Start();
            _notifyTimer.Start();
        }

        private static bool IsSteamRunning()
        {
            return Process.GetProcessesByName("steam").Length > 0;
        }

        private static void KillSteam()
        {
            foreach (var process in Process.GetProcessesByName("steam"))
            {
                process.Kill();
            }
        }

    }
}
