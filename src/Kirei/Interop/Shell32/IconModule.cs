//using System;

//using static Interop;

//namespace Kirei
//{
//    internal class IconModule : IWindowManagerChild
//    {
//        private readonly IntPtr _shellFolderViewHWnd;

//        public IconModule()
//        {
//            _shellFolderViewHWnd = GetShellFolderView();
//        }

//        public void SetVisible()
//        {
//            User32.ShowWindow(_shellFolderViewHWnd, User32.SW.RESTORE);

//            var state = new SHELLSTATE();
//            state.fHideIcons = 0;

//            Shell32.SHGetSetSettings(
//                ref state,
//                SSF.HIDEICONS,
//                true);
//        }

//        public void SetHidden()
//        {
//            User32.ShowWindow(_shellFolderViewHWnd, User32.SW.HIDE);

//            var state = new SHELLSTATE();
//            state.fHideIcons = 1;

//            Shell32.SHGetSetSettings(
//                ref state,
//                SSF.HIDEICONS,
//                true);
//        }

//        private static IntPtr GetShellFolderView()
//        {
//            var shellHWnd = User32.GetShellWindow();
//            var x = User32.GetDesktopWindow();

//            var defViewHWnd = User32.FindWindowEx(
//                x,
//                IntPtr.Zero,
//                "WorkerW",
//                string.Empty);

//            var folderViewHWnd = User32.FindWindowEx(
//                defViewHWnd,
//                IntPtr.Zero,
//                "SysListView32",
//                "FolderView");

//            return folderViewHWnd;
//        }
//    }
//}
