using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    [ComImport]
    [Guid("D8F015C0-C278-11CE-A49E-444553540000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IShellDispatch
    {
        [DispId(0x60020007)]
        void MinimizeAll();

        [DispId(0x60020008)]
        void UndoMinimizeAll();
    }
}
