using System;
using System.Runtime.InteropServices;

namespace Kirei.WindowPlugin.COM
{
    internal sealed partial class ShellClass : IDisposable
    {   
        private ShellDispatch _shell;
        private IShellDispatch _shellDispatch;

        internal ShellClass()
        {
            _shell = new ShellDispatch();
            _shellDispatch = (IShellDispatch)_shell;
        }

        internal void MinimizeAll()
        {
            if (_shellDispatch == null)
                throw new ObjectDisposedException(nameof(_shellDispatch));

            _shellDispatch.MinimizeAll();
        }

        internal void UndoMinimizeAll()
        {
            if (_shellDispatch == null)
                throw new ObjectDisposedException(nameof(_shellDispatch));

            _shellDispatch.UndoMinimizeAll();
        }

        public void Dispose()
        {
            try
            {
                if (_shellDispatch != null)
                    Marshal.ReleaseComObject(_shellDispatch);

                if (_shell != null)
                    Marshal.ReleaseComObject(_shell);
            }

            finally
            {
                _shell = null;
                _shellDispatch = null;
                GC.SuppressFinalize(this);
            }
        }
    }
}