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

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

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

        internal static int GetMonitorCount() =>
            GetSystemMetrics(80);
    }
}
