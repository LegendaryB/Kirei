using Kirei.Infrastructure.Native.Enums;
using Kirei.Infrastructure.Native.Structures;

using System;
using System.Runtime.InteropServices;

namespace Kirei.Infrastructure.Native
{
    internal static partial class User32
    {
        internal delegate bool EnumWindowProc(
            IntPtr hWnd, 
            IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetShellWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindWindowEx(
            IntPtr hWndParent, 
            IntPtr hWndChildAfter, 
            string lpszClass, 
            IntPtr lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(
            IntPtr hWnd, 
            WindowsMessages Msg, 
            IntPtr wParam, 
            IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumWindows(
            EnumWindowProc callDelegate, 
            IntPtr lParam);
    }
}
