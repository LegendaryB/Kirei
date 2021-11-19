using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Kernel32
    {
        private const string LIBRARY_NAME = "kernel32.dll";

        [DllImport(LIBRARY_NAME, SetLastError = true)]
        internal static extern EXECUTION_STATE SetThreadExecutionState(
            EXECUTION_STATE esFlags);

    }
}
