using Kirei.Infrastructure.Native;
using Kirei.Infrastructure.Native.Enums;
using Kirei.Infrastructure.Native.Structures;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Kirei.Infrastructure.DesktopAPI
{
    internal class TaskBar
    {
        private const string APPLICATION_MANAGER_SHELL = "ApplicationManager_DesktopShellWindow";

        private const string SHELL = "Shell";
        private const string TRAYWND = "TrayWnd";

        private readonly IEnumerable<IntPtr> _taskBarHandles;

        internal TaskBar()
        {
            _taskBarHandles = FetchTaskBarHandles();
        }

        internal void SetAutoHide(bool hide)
        {
            var option = hide ? AppBarStates.AutoHide : AppBarStates.AlwaysOnTop;

            var appBarData = new APPBARDATA
            {
                cbSize = (uint)Marshal.SizeOf<APPBARDATA>(),
                lParam = (int)option
            };

            foreach (var handle in _taskBarHandles)
            {
                appBarData.hWnd = handle;
                Shell32.SHAppBarMessage((uint)AppBarMessages.SetState, ref appBarData);
            }
        }

        private IEnumerable<IntPtr> FetchTaskBarHandles()
        {
            var handles = new List<IntPtr>();

            User32.EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                var className = User32.GetClassName(hWnd);

                if (className == APPLICATION_MANAGER_SHELL ||
                    !className.Contains(SHELL) ||
                    !className.Contains(TRAYWND))
                {
                    return true;
                }

                handles.Add(hWnd);

                return true;
            }, IntPtr.Zero);

            return handles;
        }
    }
}
