using Kirei.SDK;

using System;
using System.Threading.Tasks;

namespace Kirei.WindowPlugin
{
    /*
     * [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_COMMAND = 0x111;
        const int MIN_ALL = 419;
        const int MIN_ALL_UNDO = 416;

        static async Task Main(string[] args)
        {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
            System.Threading.Thread.Sleep(2000);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL_UNDO, IntPtr.Zero);
            //await CreateHostBuilder(args)
            //    .Build()
            //    .RunAsync();
        }
    */

    public sealed class Plugin : IPlugin, IDisposable
    {
        public Plugin()
        {
        }

        //public Task InitializeAsync(ILogger logger)
        //{
        //    _logger = logger;

        //    return Task.CompletedTask;
        //}

        //public Task OnActiveAsync()
        //{
        //    _shell.UndoMinimizeAll();

        //    return Task.CompletedTask;
        //}

        //public Task OnIdleAsync()
        //{
        //    _shell.MinimizeAll();

        //    return Task.CompletedTask;
        //} 

        public void Dispose()
        {
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public Task OnActivityAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnIdleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
