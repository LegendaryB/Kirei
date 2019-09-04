using Kirei.Infrastructure.Native.Structures;

using System;

namespace Kirei.Infrastructure.DesktopAPI
{
    internal class TaskBarDescriptor
    {
        internal IntPtr Handle { get; set; }
        internal RECT Position { get; set; }
    }
}
