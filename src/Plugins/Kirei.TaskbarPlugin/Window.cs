using System;

namespace Kirei.TaskbarPlugin
{
    internal class Window
    {
        internal IntPtr Handle { get; }
        internal string ClassName { get; }

        public Window(
            IntPtr hWnd,
            string className)
        {
            Handle = hWnd;
            ClassName = className;
        }
    }
}
