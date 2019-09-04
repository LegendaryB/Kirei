using Kirei.Infrastructure.Native;
using Kirei.Infrastructure.Native.Enums;

using System;

namespace Kirei.Infrastructure.DesktopAPI
{
    internal class Shell
    {
        private const string COM_OBJECT_NAME = "Shell.Application";
        private const string DefView_WINDOW_NAME = "SHELLDLL_DefView";
        private const string WorkerW_CLASS_NAME = "WorkerW";

        private readonly dynamic _shell;
        private readonly IntPtr _shellDefViewHandle;
        private readonly IntPtr _toggleDesktopIconsCmd = new IntPtr(0x7402);

        internal Shell()
        {
            _shell = CreateShellCOMInstance();
            _shellDefViewHandle = FetchShellDefViewHandle();
        }

        internal void MinimizeWindows() => _shell.MinimizeAll();

        internal void UndoMinimizeWindows() => _shell.UndoMinimizeALL();

        internal void ToggleDesktopIcons()
        {
            User32.SendMessage(
                _shellDefViewHandle,
                WindowsMessages.WM_COMMAND,
                _toggleDesktopIconsCmd,
                IntPtr.Zero);
        }

        private dynamic CreateShellCOMInstance()
        {
            var type = Type.GetTypeFromProgID(COM_OBJECT_NAME);
            return Activator.CreateInstance(type);
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
