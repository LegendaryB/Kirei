using Kirei.Native;
using Kirei.Native.Enums;

using System;

namespace Kirei
{
    internal class Desktop
    {
        private const string DefView_HOST_WINDOW_NAME = "Progman";
        private const string DefView_WINDOW_NAME = "SHELLDLL_DefView";
        private const string Taskbar_WINDOW_NAME = "Shell_TrayWnd";

        private readonly IntPtr _command = new IntPtr(0x7402);

        private IntPtr shellDefViewHwnd;
        private IntPtr taskbarHwnd;

        internal void ToggleIcons()
        {
            if (!User32.IsWindow(shellDefViewHwnd)) // window handle is not valid anymore
                shellDefViewHwnd = GetShellDefView();

            if (shellDefViewHwnd == IntPtr.Zero)
                return;

            User32.SendMessage(
                shellDefViewHwnd, 
                WindowsMessages.COMMAND, 
                _command, 
                IntPtr.Zero);
        }

        internal void ToggleTaskbar()
        {
            if (!User32.IsWindow(taskbarHwnd)) // window handle is not valid anymore
                taskbarHwnd = User32.FindWindow(Taskbar_WINDOW_NAME, null);

            if (User32.IsWindowVisible(taskbarHwnd))
                User32.ShowWindow(taskbarHwnd, 0);
            else
                User32.ShowWindow(taskbarHwnd, 1);
        }

        private IntPtr GetShellDefView()
        {
            var progmanHwnd = User32.FindWindow(DefView_HOST_WINDOW_NAME, null);

            var shellDefViewHwnd = User32.FindWindowEx(
                progmanHwnd, 
                IntPtr.Zero,
                DefView_WINDOW_NAME, 
                IntPtr.Zero);

            if (shellDefViewHwnd != IntPtr.Zero)
                return shellDefViewHwnd;

            User32.EnumWindows(delegate (IntPtr hwnd, IntPtr lParam)
            {
                //not a WorkerW
                //if (!BFS.Window.GetClass(hwnd).Equals("WorkerW", StringComparison.OrdinalIgnoreCase))
                //    return true;

                shellDefViewHwnd = User32.FindWindowEx(
                    hwnd,
                    IntPtr.Zero, 
                    DefView_WINDOW_NAME, 
                    IntPtr.Zero);

                if (shellDefViewHwnd == IntPtr.Zero)
                    return true;

                return false;
            }, IntPtr.Zero);

            return shellDefViewHwnd;
        }
    }
}
