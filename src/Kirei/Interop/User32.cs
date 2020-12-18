using System;
using System.Runtime.InteropServices;
using System.Text;

internal static partial class Interop
{
    internal static class User32
    {
        private const string DLL_NAME = "user32.dll";

        internal delegate bool EnumWindowProc(
            IntPtr hWnd,
            IntPtr lParam);

        internal enum SW : int
        {
            HIDE = 0,
            RESTORE = 9
        }        

        [DllImport(DLL_NAME)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumWindows(
            EnumWindowProc callDelegate,
            IntPtr lParam);
        
        internal static string GetClassName(IntPtr hWnd)
        {
            var className = new StringBuilder(256);
            GetClassName(hWnd, className, className.Capacity);

            return className.ToString();
        }

        [DllImport(DLL_NAME)]
        internal static extern bool ShowWindow(
            IntPtr hWnd, 
            SW nCmdShow);

        [DllImport(DLL_NAME)]
        internal static extern IntPtr GetShellWindow();

        [DllImport(DLL_NAME)]
        internal static extern IntPtr GetDesktopWindow();

        [DllImport(DLL_NAME, CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindWindowEx(
            IntPtr hWndParent,
            IntPtr hWndChildAfter,
            string lpszClass,
            string lpszWindow);


        [DllImport(DLL_NAME, CharSet = CharSet.Unicode)]
        private static extern int GetClassName(
            IntPtr hWnd,
            StringBuilder lpClassName,
            int nMaxCount);
    }
}
