using Kirei.Domain.Native.Enums;

using System.Runtime.InteropServices;

namespace Kirei.Infrastructure.Native
{
    internal static class Kernel32
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern ExecutionStates SetThreadExecutionState(ExecutionStates esFlags);
    }
}
