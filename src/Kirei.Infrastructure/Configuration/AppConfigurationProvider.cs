using Kirei.Application.Configuration;
using Kirei.Domain.Configuration;

using Microsoft.Extensions.Configuration;

using System;
using System.IO;

namespace Kirei.Infrastructure.Configuration
{
    public static class AppConfigurationProvider
    {
        public static IAppConfiguration Configuration { get; private set; }

        private const string SETTINGS_FILE = "appsettings.json";

        private static readonly string _basePath;
        private static readonly AppConfigurationFileWatcher _fileWatcher;

        static AppConfigurationProvider()
        {
            _basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            _fileWatcher = new AppConfigurationFileWatcher(() =>
            {
                Load(false);
            });

            Load();
        }

        private static void Load(bool attachFileWatcher = true)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(_basePath)
                   .AddJsonFile(SETTINGS_FILE, false);

            var configuration = builder.Build();

            var appConfiguration = configuration.Get<AppConfiguration>();

            appConfiguration.InactiveStateInSeconds =
                appConfiguration.InactiveStateInSeconds == 0 ? 180 : appConfiguration.InactiveStateInSeconds;

            appConfiguration.InactiveStateInMilliseconds = appConfiguration.InactiveStateInSeconds * 1000;

            Configuration = appConfiguration;

            if (attachFileWatcher)
                _fileWatcher.WatchForChanges(
                    SETTINGS_FILE,
                    _basePath);
        }
    }
}
