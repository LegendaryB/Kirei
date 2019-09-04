using Kirei.Application.Configuration;
using Kirei.Domain.Configuration;
using MediatR;
using System.IO;

namespace Kirei.Infrastructure.Configuration
{
    public class AppConfigurationFileWatcher :
        IAppConfigurationFileWatcher
    {
        private readonly IMediator _mediator;
        private readonly FileSystemWatcher _fileWatcher;

        public AppConfigurationFileWatcher(IMediator mediator)
        {
            _mediator = mediator;
            _fileWatcher = new FileSystemWatcher();
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

        private async void OnAppConfigurationFileChanged(object sender, FileSystemEventArgs e)
        {
            await _mediator.Send(new AppConfigurationFileChanged());
        }

        public void Dispose()
        {
            _fileWatcher.Changed -= OnAppConfigurationFileChanged;
            _fileWatcher.Dispose();
        }
    }
}
