using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Kirei.Infrastructure.Native.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct APPBARDATA
    {
        public uint cbSize;
        public IntPtr hWnd;
        public uint uCallbackMessage;
        public uint uEdge;
        public Rectangle rc;
        public int lParam;
    }
}
