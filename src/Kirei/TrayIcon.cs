using System.Drawing;
using System.Windows.Forms;

namespace Kirei
{
    internal class TrayIcon
    {
        private readonly NotifyIcon _notifyIcon;

        public TrayIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "Kirei";
            _notifyIcon.Visible = true;
            _notifyIcon.Icon = new Icon("kirei.ico");
        }
    }
}
