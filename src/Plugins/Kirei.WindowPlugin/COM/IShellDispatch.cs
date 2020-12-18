using System;
using System.Runtime.InteropServices;

namespace Kirei.WindowPlugin.COM
{
    // todo: remove com stuff and use winapi with sendmessage
    [ComImport]
    [Guid("D8F015C0-C278-11CE-A49E-444553540000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    internal interface IShellDispatch
    {
        [DispId(0x60020007)]
        void MinimizeAll();

        [DispId(0x60020008)]
        void UndoMinimizeAll();
    }
}
