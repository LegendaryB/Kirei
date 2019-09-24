using System.Diagnostics;

namespace Kirei.Watchdog
{
    internal class App
    {
        private readonly string _appFilePath;
        private readonly string _appStateFilePath;
        private readonly Process _process;

        internal App(string appFilePath, string appStateFilePath, int processId)
        {
            _appFilePath = appFilePath;
            _appStateFilePath = appStateFilePath;
            _process = Process.GetProcessById(processId);
        }

        internal void Run()
        {
            _process.WaitForExit();

            // todo dbelz: add logic to restore previous state and restart kirei
        }
    }
}
