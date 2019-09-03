using System;

namespace Kirei.Infrastructure.DesktopAPI
{
    internal class Shell
    {
        private const string COM_OBJECT_NAME = "Shell.Application"; 

        private readonly dynamic _shell;       

        internal Shell()
        {
            _shell = CreateShellCOMInstance();
            
        }

        internal void MinimizeWindows() => _shell.MinimizeAll();
        internal void UndoMinimizeWindows() => _shell.UndoMinimizeALL();

        private dynamic CreateShellCOMInstance()
        {
            var type = Type.GetTypeFromProgID(COM_OBJECT_NAME);
            return Activator.CreateInstance(type);
        }
    }
}
