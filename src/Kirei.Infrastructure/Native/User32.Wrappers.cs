using Kirei.Infrastructure.Native.Enums;
using Kirei.Infrastructure.Native.Structures;

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Kirei.Infrastructure.Native
{
    internal static partial class User32
    {
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassName(
            IntPtr hWnd,
            StringBuilder lpClassName,
            int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int x,
            int y,
            int cx,
            int cy,
            SetWindowPosFlags uFlags
        );

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(
            IntPtr hwnd,
            ref RECT rectangle);

        internal static long GetUserIdleTime()
        {
            var lastInputStruct = new LASTINPUTINFO();
            lastInputStruct.cbSize = (uint)Marshal.SizeOf(lastInputStruct);

            GetLastInputInfo(ref lastInputStruct);

            return ((uint)Environment.TickCount - lastInputStruct.dwTime);
        }
        
        internal static string GetClassName(IntPtr hWnd)
        {
            var className = new StringBuilder(256);
            GetClassName(hWnd, className, className.Capacity);

            return className.ToString();
        }

        internal static int SetWindowPos(
            IntPtr hWnd,
            RECT rect,
            SetWindowPosFlags uFlags)
        {
            var cx = rect.Right - rect.Left;
            var cy = rect.Bottom - rect.Top;

            return SetWindowPos(
                hWnd,
                IntPtr.Zero, 
                rect.Left, 
                rect.Top,
                cx,
                cy,
                uFlags);
        }

        internal static RECT GetWindowRect(IntPtr hWnd)
        {
            var rect = new RECT();
            GetWindowRect(hWnd, ref rect);

            return rect;
        }
    }
}
