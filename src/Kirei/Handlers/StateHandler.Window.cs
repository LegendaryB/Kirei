using System;

using static Interop;

namespace Kirei
{
    internal sealed class WindowStateHandler : StateHandler,
        IDisposable
    {
        private readonly ShellClass _shell;

        public WindowStateHandler()
        {
            _shell = new ShellClass();
        }

        protected override void OnAppearing() =>
            _shell.MinimizeAll();

        protected override void OnDisappearing() =>
            _shell.UndoMinimizeAll();

        public void Dispose()
        {
            _shell?.Dispose();
        }
    }
}
