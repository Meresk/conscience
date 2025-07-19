using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace conscience
{
    public class TrayManager : IDisposable
    {
        private readonly System.Windows.Forms.NotifyIcon _notifyIcon;
        private readonly Window _mainWindow;

        public TrayManager(MainWindow mainWindow)
        {
            _mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            _notifyIcon = new NotifyIcon();
            InitializeTrayIcon();
        }

        private void InitializeTrayIcon()
        {
            _notifyIcon.Icon = new System.Drawing.Icon("Resources/shield.ico");
            _notifyIcon.Text = "Conscience";
            _notifyIcon.MouseClick += OnTrayIconClick;
            _notifyIcon.Visible = true;
        }

        private void OnTrayIconClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowMainWindow();
            }
        }

        public void ShowMainWindow()
        {
            _mainWindow.Show();
            _mainWindow.WindowState = WindowState.Normal;
            _mainWindow.Activate();
        }

        public void ShowNotification(string title, string message, ToolTipIcon icon = ToolTipIcon.Info)
        {
            _notifyIcon.ShowBalloonTip(3000, title, message, icon);
        }

        public void Dispose()
        {
            _notifyIcon.Dispose();
        }
    }
}
