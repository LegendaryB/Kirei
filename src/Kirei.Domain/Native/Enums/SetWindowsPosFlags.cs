using System;

namespace Kirei.Domain.Native.Enums
{
    [Flags]
    public enum SetWindowPosFlags : uint
    {
        HideWindow = 0x0080,
        ShowWindow = 0x0040,
    }
}
