using System;

using static Interop;

namespace Kirei
{
    internal class WindowModule : IWindowManagerChild,
        IDisposable
    {
        private readonly ShellClass _shell =
            new ShellClass();

        public void SetVisible() => _shell.UndoMinimizeAll();
        public void SetHidden() => _shell.MinimizeAll();

        public void Dispose()
        {
            _shell?.Dispose();
        }
    }
}
