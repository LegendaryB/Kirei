using System;

using static Interop;

namespace Kirei
{
    internal class DesktopIconManager
    {
        private VisualState _state;
        private readonly IntPtr _shellFolderViewHWnd;

        internal DesktopIconManager()
        {
            _shellFolderViewHWnd = GetShellFolderView();
        }

        internal void Show()
        {
            if (_state == VisualState.Visible)
                return;

            User32.ShowWindow(_shellFolderViewHWnd, User32.SW.RESTORE);

            var state = new SHELLSTATE();
            state.fHideIcons = 0;

            Shell32.SHGetSetSettings(
                ref state,
                SSF.HIDEICONS,
                true);

            _state = VisualState.Visible;
        }

        internal void Hide()
        {
            if (_state == VisualState.Hidden)
                return;

            User32.ShowWindow(_shellFolderViewHWnd, User32.SW.HIDE);

            var state = new SHELLSTATE();
            state.fHideIcons = 1;

            Shell32.SHGetSetSettings(
                ref state,
                SSF.HIDEICONS,
                true);

            _state = VisualState.Hidden;
        }

        private static IntPtr GetShellFolderView()
        {
            var shellHWnd = User32.GetShellWindow();

            var defViewHWnd = User32.FindWindowEx(
                shellHWnd,
                IntPtr.Zero,
                "SHELLDLL_DefView",
                string.Empty);

            var folderViewHWnd = User32.FindWindowEx(
                defViewHWnd,
                IntPtr.Zero,
                "SysListView32",
                "FolderView");

            return folderViewHWnd;
        }
    }
}
