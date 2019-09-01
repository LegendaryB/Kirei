using Kirei.Application;
using Kirei.Infrastructure.Native;
using Kirei.Infrastructure.Native.Enums;

using System;

namespace Kirei.Infrastructure
{
    public class DesktopAPI :
        IDesktopAPI
    {
        private const string DefView_HOST_WINDOW_NAME = "Progman";
        private const string DefView_WINDOW_NAME = "SHELLDLL_DefView";
        private const string Taskbar_WINDOW_NAME = "Shell_TrayWnd";
        private const string WorkerW_CLASS_NAME = "WorkerW";

        private readonly IntPtr _command = new IntPtr(0x7402);

        private bool hasMinimizedWindows = false;

        private IntPtr ShellDefViewHwnd;
        private IntPtr TaskBarHwnd;

        public void ToggleTaskBar()
        {
            if (!User32.IsWindow(TaskBarHwnd)) // window handle is not valid anymore
                TaskBarHwnd = User32.FindWindow(Taskbar_WINDOW_NAME, null);

            if (User32.IsWindowVisible(TaskBarHwnd))
                User32.ShowWindow(TaskBarHwnd, 0);
            else
                User32.ShowWindow(TaskBarHwnd, 1);
        }

        public void ToggleIcons()
        {
            if (!TryGetShellDefView())
                return;

            User32.SendMessage(
                ShellDefViewHwnd,
                WindowsMessages.WM_COMMAND,
                _command,
                IntPtr.Zero);
        }

        public void ToggleWindows()
        {
            if (!TryGetShellDefView())
                return;

            uint cmd;

            if (hasMinimizedWindows)
                cmd = (uint)SystemCommands.SC_RESTORE;
            else
                cmd = (uint)SystemCommands.SC_MINIMIZE;

            User32.SendMessage(
                ShellDefViewHwnd,
                WindowsMessages.WM_COMMAND,
                new IntPtr(cmd),
                IntPtr.Zero);
        }

        private bool TryGetShellDefView()
        {
            if (User32.IsWindow(ShellDefViewHwnd))
                return true;

            ShellDefViewHwnd = GetShellDefView();

            return ShellDefViewHwnd != IntPtr.Zero;
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

            User32.EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                if (!User32.GetClassName(hWnd).Equals(WorkerW_CLASS_NAME, StringComparison.OrdinalIgnoreCase))
                    return true;

                shellDefViewHwnd = User32.FindWindowEx(
                    hWnd,
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
