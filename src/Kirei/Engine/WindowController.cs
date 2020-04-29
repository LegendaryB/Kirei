using System;

using static Interop;

namespace Kirei.Engine
{
    internal sealed class WindowController : StateControllerBase,
        IStateController,
        IDisposable
    {
        private readonly ShellClass _shell;

        public WindowController()
        {
            _shell = new ShellClass();
        }

        protected override void OnAppearing() =>
            _shell.UndoMinimizeAll();

        protected override void OnDisappearing() =>
            _shell.MinimizeAll();

        public void Dispose()
        {
            _shell?.Dispose();
        }
    }
}
