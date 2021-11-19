using System.Runtime.InteropServices;

internal static partial class Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct LASTINPUTINFO
    {
        [MarshalAs(UnmanagedType.U4)]
        internal uint cbSize;

        [MarshalAs(UnmanagedType.U4)]
        internal uint dwTime;

        internal static LASTINPUTINFO Create()
        {
            return new LASTINPUTINFO
            {
                cbSize = (uint)Marshal.SizeOf<LASTINPUTINFO>()
            };
        }
    }
}
