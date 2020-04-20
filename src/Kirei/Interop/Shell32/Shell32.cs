using System;
using System.Runtime.InteropServices;

namespace Kirei.Interop.Shell
{
    internal sealed class Shell32 : IDisposable
    {
        ShellClass shell;
        IShellDispatch shellDispatch;

        public Shell32()
        {
            shell = new ShellClass();
            shellDispatch = (IShellDispatch)shell;
        }

        public void MinimizeAll()
        {
            if (shellDispatch == null)
                throw new ObjectDisposedException("Shell");

            shellDispatch.MinimizeAll();
        }

        public void Dispose()
        {
            try
            {
                if (shellDispatch != null)
                    Marshal.ReleaseComObject(shellDispatch);

                if (shell != null)
                    Marshal.ReleaseComObject(shell);
            }

            finally
            {
                shell = null;
                shellDispatch = null;
                GC.SuppressFinalize(this);
            }
        }
    }
}
