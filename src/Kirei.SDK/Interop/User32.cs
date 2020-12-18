using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Kirei.SDK.Interop
{
    public static class User32
    {
        private const string LibName = "user32.dll";

        public delegate bool EnumWindowProc(
            IntPtr hWnd,
            IntPtr lParam);

        [DllImport(LibName)]
        public static extern bool ShowWindow(
            IntPtr hWnd,
            SW nCmdShow);

        [DllImport(LibName)]
        public static extern bool EnumWindows(
            EnumWindowProc callDelegate,
            IntPtr lParam);

        [DllImport(LibName, CharSet = CharSet.Unicode)]
        private static extern int GetClassName(
            IntPtr hWnd,
            StringBuilder lpClassName,
            int nMaxCount);        



        public static string GetClassName(IntPtr hWnd)
        {
            var className = new StringBuilder(256);
            GetClassName(hWnd, className, className.Capacity);

            return className.ToString();
        }
    }
}
