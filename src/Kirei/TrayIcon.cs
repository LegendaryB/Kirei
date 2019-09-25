using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kirei
{
    internal class TrayIcon
    {
        private readonly NotifyIcon _notifyIcon;

        public TrayIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "Hello";
            _notifyIcon.Visible = true;
            _notifyIcon.Icon = new Icon("kirei.ico", 256, 256);
        }
    }
}
