using Kirei.Native.Enums;
using Kirei.Native.Structures;

using System;
using System.Runtime.InteropServices;

namespace Kirei.Native
{
    internal static class User32
    {
        internal delegate bool EnumWindowProc(
            IntPtr hWnd, 
            IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern IntPtr FindWindow(
            string lpClassName, 
            string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindWindowEx(
            IntPtr hWndParent, 
            IntPtr hWndChildAfter, 
            string lpszClass, 
            IntPtr lpszWindow);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetWindow(
            IntPtr hWnd, 
            GetWindowTypes uCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(
            IntPtr hWnd, 
            WindowsMessages Msg, 
            IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumWindows(
            EnumWindowProc callDelegate, 
            IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern int ShowWindow(
            IntPtr hWnd, 
            int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        internal static long GetLastInputTimeInMilliseconds()
        {
            var lastInputStruct = new LASTINPUTINFO();
            lastInputStruct.cbSize = (uint)Marshal.SizeOf(lastInputStruct);

            GetLastInputInfo(ref lastInputStruct);

            return ((uint)Environment.TickCount - lastInputStruct.dwTime);
        }
    }
}
