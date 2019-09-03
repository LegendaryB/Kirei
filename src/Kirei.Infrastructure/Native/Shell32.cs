using Kirei.Infrastructure.Native.Structures;

using System.Runtime.InteropServices;

namespace Kirei.Infrastructure.Native
{
    internal static class Shell32
    {
        [DllImport("shell32.dll")]
        public static extern uint SHAppBarMessage(uint dwMessage, ref APPBARDATA pData);
    }
}
