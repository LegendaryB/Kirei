using System;

using static Interop;

namespace Kirei
{
    internal class WindowModule : IWindowManagerModule,
        IDisposable
    {
        private readonly ShellClass _shell;

        public WindowModule()
        {
            _shell = new ShellClass();
        }

        //protected override void OnAppearing() =>
        //    _shell.UndoMinimizeAll();

        //protected override void OnDisappearing() =>
        //    _shell.MinimizeAll();

        public void Dispose()
        {
            _shell?.Dispose();
        }
    }
}
