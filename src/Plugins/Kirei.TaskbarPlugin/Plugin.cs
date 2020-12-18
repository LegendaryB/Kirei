using Kirei.SDK;
using Kirei.SDK.Interop;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kirei.TaskbarPlugin
{
    public sealed class Plugin : IPlugin
    {
        private readonly List<TaskbarWindow> _windows;

        public IPluginMetadata Metadata { get; }

        public Plugin()
        {
            _windows = new List<TaskbarWindow>();

            Metadata = new PluginMetadata();
        }

        public async Task InitializeAsync()
        {
            var windows = await FindTaskbarWindowsAsync();
            _windows.AddRange(windows);
        }

        public Task OnActiveAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task OnIdleAsync()
        {
            throw new System.NotImplementedException();
        }

        private Task<List<TaskbarWindow>> FindTaskbarWindowsAsync()
        {
            var tcs = new TaskCompletionSource<List<TaskbarWindow>>();
            var windows = new List<TaskbarWindow>();

            bool enumWindowsProc(IntPtr hWnd, IntPtr lParam)
            {
                var lpClassName = User32.GetClassName(hWnd);

                if (lpClassName.StartsWith("Shell_") && lpClassName.EndsWith("TrayWnd"))
                {
                    windows.Add(TaskbarWindow.Create(
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

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
