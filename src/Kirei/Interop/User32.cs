using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static class User32
    {
        private const string LIBRARY_NAME = "user32.dll";

        [DllImport(LIBRARY_NAME)]
        internal static extern bool GetLastInputInfo(
            ref LASTINPUTINFO plii);
    }
}
