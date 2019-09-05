using System;

namespace Kirei.Domain.Native.Enums
{
    [Flags]
    public enum ExecutionStates : uint
    {
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_CONTINUOUS = 0x80000000
    }
}
