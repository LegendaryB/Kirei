using Kirei.Infrastructure.Native;

using System;
using System.Runtime.InteropServices;

namespace Kirei.Infrastructure.DesktopAPI
{
    internal class TaskBar
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(
            IntPtr hWnd,
            int nCmdShow);

        private const string SHELL_TRAYWND = "Shell_TrayWnd";
        private const string SYSTEM_TRAYWND = "System_TrayWnd";

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        /// <summary>
        /// Completely hide the taskbar. Useful combined with SetTaskbarState.
        /// </summary>
        /// <param name="hidden">true for hidden taskbar, false to restore</param>

        public void SetTaskBarHidden(bool hidden)
        {
            var count = User32.GetMonitorCount();
            IntPtr hwnd = User32.FindWindow("Shell_TrayWnd", "");
            
            ShowWindow(hwnd, hidden ? SW_HIDE : SW_SHOW);
        }

        //private IntPtr FetchTaskBarHandle()
        //{
        //    var handle = User32.FindWindow(SYSTEM_TRAYWND, null);

        //    if (handle == IntPtr.Zero)
        //        handle = User32.FindWindow(SHELL_TRAYWND, null);

        //    return handle;
        //}
    }
}
