using Kirei.Application.Configuration;
using Kirei.Domain.Configuration;
using MediatR;
using Microsoft.Extensions.Configuration;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kirei.Infrastructure.Configuration
{
    public class AppConfigurationProvider :
        AsyncRequestHandler<AppConfigurationFileChanged>,
        IAppConfigurationProvider
    {
        public IAppConfiguration Configuration { get; private set; }

        private const string SETTINGS_FILE = "appsettings.json";

        private readonly string _basePath;
        private readonly IAppConfigurationFileWatcher _fileWatcher;
        private readonly object _configurationLock;

        public AppConfigurationProvider(IAppConfigurationFileWatcher fileWatcher)
        {
            _basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            _fileWatcher = fileWatcher;
            _configurationLock = new object();

            Load();
        }

        protected override Task Handle(AppConfigurationFileChanged request, CancellationToken cancellationToken)
        {
            Load();
            return Task.CompletedTask;
        }

        private void Load()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(_basePath)
                   .AddJsonFile(SETTINGS_FILE, false);

            var configuration = builder.Build();

            var appConfiguration = configuration.Get<AppConfiguration>();

            appConfiguration.InactiveStateInSeconds =
                appConfiguration.InactiveStateInSeconds == 0 ? 180 : appConfiguration.InactiveStateInSeconds;

            appConfiguration.InactiveStateInMilliseconds = appConfiguration.InactiveStateInSeconds * 1000;

            _fileWatcher.WatchForChanges(
                SETTINGS_FILE,
                _basePath);

            lock (_configurationLock)
            {
                Configuration = appConfiguration;
            }
        }

        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
