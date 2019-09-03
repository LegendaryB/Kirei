using Kirei.Application;
using Kirei.Infrastructure.Native;
using Kirei.Infrastructure.Native.Enums;

using System;

namespace Kirei.Infrastructure.DesktopAPI
{
    public class Desktop :
        IDesktop
    {
        private const string DefView_WINDOW_NAME = "SHELLDLL_DefView";
        private const string WorkerW_CLASS_NAME = "WorkerW";

        private readonly IntPtr _command = new IntPtr(0x7402);

        private readonly Shell _shell;
        private readonly TaskBar _taskBar;
        private readonly IntPtr _shellDefViewHandle;

        private bool windowsMinimized = false;

        public Desktop()
        {
            _shell = new Shell();
            _taskBar = new TaskBar();
            _shellDefViewHandle = FetchShellDefViewHandle();
        }

        public void ToggleTaskBar()
        {
            _taskBar.SetTaskBarHidden(false);
        }

        public void ToggleIcons()
        {
            User32.SendMessage(
                _shellDefViewHandle,
                WindowsMessages.WM_COMMAND,
                _command,
                IntPtr.Zero);
        }

        public void ToggleWindows()
        {
            if (windowsMinimized)
            {
                _shell.UndoMinimizeWindows();
                windowsMinimized = false;
            }
            else
            {
                _shell.MinimizeWindows();
                windowsMinimized = true;
            }
        }

        private IntPtr FetchShellDefViewHandle()
        {
            var shellWindowHandle = User32.GetShellWindow();
            IntPtr handle = default;

            User32.EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                if (!User32.GetClassName(hWnd).Equals(WorkerW_CLASS_NAME, StringComparison.OrdinalIgnoreCase))
                    return true;

                handle = User32.FindWindowEx(
                    hWnd,
                    IntPtr.Zero,
                    DefView_WINDOW_NAME,
                    IntPtr.Zero);

                if (handle == IntPtr.Zero)
                    return true;

                return false;
            }, IntPtr.Zero);

            return handle;
        }
    }
}
