using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static class Kernel32
    {
        private const string DLL_NAME = "kernel32.dll";

        [Flags]
        internal enum EXECUTION_STATE : uint
        {
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_CONTINUOUS = 0x80000000
        }

        [DllImport(DLL_NAME, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
    }
}
