using System;
using System.IO;

namespace Kirei.Infrastructure.Configuration
{
    internal class AppConfigurationFileWatcher
    {
        private readonly FileSystemWatcher _fileWatcher;
        private readonly Action _onFileChangedCallback;

        public AppConfigurationFileWatcher(Action onFileChangedCallback)
        {
            _fileWatcher = new FileSystemWatcher();
            _onFileChangedCallback = onFileChangedCallback;
        }

        public void WatchForChanges(
            string file,
            string path)
        {
            _fileWatcher.Path = path;
            _fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            _fileWatcher.Filter = file;

            _fileWatcher.Changed += OnAppConfigurationFileChanged;

            _fileWatcher.EnableRaisingEvents = true;
        }

        private void OnAppConfigurationFileChanged(object sender, FileSystemEventArgs e) =>
            _onFileChangedCallback?.Invoke();

        public void Dispose()
        {
            _fileWatcher.Changed -= OnAppConfigurationFileChanged;
            _fileWatcher.Dispose();
        }
    }
}
