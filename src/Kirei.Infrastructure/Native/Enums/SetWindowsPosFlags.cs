using System;

namespace Kirei.Infrastructure.Native.Enums
{
    [Flags]
    internal enum SetWindowPosFlags : uint
    {
        HideWindow = 0x0080,
        ShowWindow = 0x0040,
    }
}
