using Kirei.Domain.Native.Structures;

using System;

namespace Kirei.Domain.Desktop
{
    public class TaskBarDescriptor
    {
        public IntPtr Handle { get; set; }
        public RECT Position { get; set; }
    }
}
