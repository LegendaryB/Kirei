using Kirei.SDK;
using Kirei.SDK.Interop;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kirei.TaskbarPlugin
{
    public sealed class Plugin : IPlugin
    {
        private const string CLASSNAME_START_IDENTIFIER = "Shell_";
        private const string CLASSNAME_END_IDENTIFIER = "TrayWnd";

        private List<Window> _windows;

        public async Task InitializeAsync()
        {
            _windows = await FindTaskbarWindowsAsync();
        }

        public Task OnActivityAsync()
        {
            return Task.CompletedTask;
        }

        public Task OnIdleAsync()
        {
            return Task.CompletedTask;
        }

        private Task<List<Window>> FindTaskbarWindowsAsync()
        {
            var tcs = new TaskCompletionSource<List<Window>>();
            var windows = new List<Window>();

            bool enumWindowsProc(IntPtr hWnd, IntPtr lParam)
            {
                var lpClassName = User32.GetClassName(hWnd);

                if (lpClassName.StartsWith(CLASSNAME_START_IDENTIFIER) && lpClassName.EndsWith(CLASSNAME_END_IDENTIFIER))
                {
                    windows.Add(new Window(
                        hWnd,
                        lpClassName));
                }

                return true;
            }

            User32.EnumWindows(
                enumWindowsProc,
                IntPtr.Zero);

            tcs.SetResult(windows);

            return tcs.Task;
        }
    }
}
