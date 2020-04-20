using System;
using System.Collections.Generic;

using static Interop;

namespace Kirei
{
    internal partial class TaskbarManager
    {   
        private readonly List<Taskbar> _taskbarList;

        internal TaskbarManager()
        {
            _taskbarList = GetTaskbarWindows();
        }

        internal void Show()
        {
            foreach (var taskbar in _taskbarList)
            {
                if (taskbar.Visibility == VisualState.Visible)
                    continue;

                if (User32.ShowWindow(taskbar.HWnd, User32.SW.RESTORE))
                    taskbar.Visibility = VisualState.Visible;
            }
        }

        internal void Hide()
        {
            foreach (var taskbar in _taskbarList)
            {
                if (taskbar.Visibility == VisualState.Hidden)
                    continue;

                if (User32.ShowWindow(taskbar.HWnd, User32.SW.HIDE))
                    taskbar.Visibility = VisualState.Hidden;
            }
        }

        private List<Taskbar> GetTaskbarWindows()
        {
            var taskbarList = new List<Taskbar>();

            User32.EnumWindows(
                (hWnd, _) => EnumWindowsCallback(hWnd, taskbarList), 
                IntPtr.Zero);

            return taskbarList;
        }

        private bool EnumWindowsCallback(
            IntPtr hWnd, 
            List<Taskbar> results)
        {
            var lpClassName = User32.GetClassName(hWnd);

            if (lpClassName.StartsWith("Shell_") && lpClassName.EndsWith("TrayWnd"))
                results.Add(new Taskbar(hWnd));

            return true;
        }
    }
}
