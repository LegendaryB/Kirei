using System;

namespace Kirei
{
    internal partial class TaskbarManager
    {
        private class Taskbar
        {
            internal IntPtr HWnd { get; set; }
            internal VisualState Visibility { get; set; }

            internal Taskbar(IntPtr hWnd)
            {
                if (hWnd.Equals(IntPtr.Zero))
                    throw new ArgumentException(nameof(hWnd));

                HWnd = hWnd;
                Visibility = VisualState.Visible;
            }
        }
    }
}
