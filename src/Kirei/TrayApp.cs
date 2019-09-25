using System.Drawing;
using System.Windows.Forms;

namespace Kirei
{
    internal class TrayApp
    {
        private readonly NotifyIcon _trayIcon;

        internal TrayApp()
        {
            _trayIcon = new NotifyIcon
            {
                Text = "Kirei",
                Visible = true,
                Icon = new Icon("kirei.ico"),
                ContextMenu = CreateContextMenu()
            };
        }

        private ContextMenu CreateContextMenu()
        {
            var contextMenu = new ContextMenu();

            return contextMenu;
        }
    }
}
