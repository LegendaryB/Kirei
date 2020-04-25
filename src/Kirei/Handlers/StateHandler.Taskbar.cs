using System;
using System.Collections.Generic;

using static Interop;

namespace Kirei
{
    internal partial class TaskbarStateHandler : StateHandler
    {   
        private readonly List<IntPtr> _hWndList;

        internal TaskbarStateHandler()
        {
            _hWndList = GetTaskbarWindows();
        }

        protected override void OnAppearing()
        {
            foreach (var hWnd in _hWndList)
                User32.ShowWindow(hWnd, User32.SW.RESTORE);
        }

        protected override void OnDisappearing()
        {
            foreach (var hWnd in _hWndList)
                User32.ShowWindow(hWnd, User32.SW.HIDE);
        }

        private List<IntPtr> GetTaskbarWindows()
        {
            var hWndList = new List<IntPtr>();

            User32.EnumWindows(
                (hWnd, _) => EnumWindowsCallback(hWnd, hWndList), 
                IntPtr.Zero);

            return hWndList;
        }

        private bool EnumWindowsCallback(
            IntPtr hWnd, 
            List<IntPtr> results)
        {
            var lpClassName = User32.GetClassName(hWnd);

            if (lpClassName.StartsWith("Shell_") && lpClassName.EndsWith("TrayWnd"))
                results.Add(hWnd);

            return true;
        }
    }
}
