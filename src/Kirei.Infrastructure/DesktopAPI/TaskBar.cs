using Kirei.Infrastructure.Native;
using Kirei.Infrastructure.Native.Enums;
using Kirei.Infrastructure.Native.Structures;

using System;
using System.Collections.Generic;

namespace Kirei.Infrastructure.DesktopAPI
{
    internal class TaskBar
    {
        private const string APPLICATION_MANAGER_SHELL = "ApplicationManager_DesktopShellWindow";

        private const string SHELL = "Shell";
        private const string TRAYWND = "TrayWnd";

        private readonly List<TaskBarDescriptor> _taskBarDescriptorList;
        private readonly RECT _emptyRect = new RECT();

        internal TaskBar()
        {
            _taskBarDescriptorList = FetchTaskBarHandles();
        }

        internal void Show()
        {
            foreach (var descriptor in _taskBarDescriptorList)
                User32.SetWindowPos(descriptor.Handle, descriptor.Position, SetWindowPosFlags.ShowWindow);
        }

        internal void Hide()
        {
            foreach (var descriptor in _taskBarDescriptorList)
                User32.SetWindowPos(descriptor.Handle, _emptyRect, SetWindowPosFlags.HideWindow);
        }

        private List<TaskBarDescriptor> FetchTaskBarHandles()
        {
            var taskBarDescriptorList = new List<TaskBarDescriptor>();

            User32.EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                var className = User32.GetClassName(hWnd);

                if (className == APPLICATION_MANAGER_SHELL ||
                    !className.Contains(SHELL) ||
                    !className.Contains(TRAYWND))
                {
                    return true;
                }

                var descriptor = new TaskBarDescriptor
                {
                    Handle = hWnd,
                    Position = User32.GetWindowRect(hWnd)
                };

                taskBarDescriptorList.Add(descriptor);

                return true;
            }, IntPtr.Zero);

            return taskBarDescriptorList;
        }
    }
}
