using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static class Shell32
    {
        private const string DLL_NAME = "shell32.dll";

        [DllImport(DLL_NAME)]
        internal extern static void SHGetSetSettings(ref SHELLSTATE lpss, SSF dwMask, bool bSet);
    }
}
