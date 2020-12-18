using System;

namespace Kirei.TaskbarPlugin
{
    internal class TaskbarWindow
    {
        internal IntPtr Handle { get; }
        internal string ClassName { get; }

        private TaskbarWindow(
            IntPtr hWnd,
            string className)
        {
            Handle = hWnd;
            ClassName = className;
        }

        internal static TaskbarWindow Create(
            IntPtr hWnd,
            string className)
        {
            if (hWnd == default)
                throw new InvalidOperationException();

            return new TaskbarWindow(
                hWnd,
                className);
        }
    }
}
