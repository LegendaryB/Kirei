using Kirei.Application.Configuration;
using Kirei.Domain.Configuration;

using Microsoft.Extensions.Configuration;

using System;
using System.IO;

namespace Kirei.Infrastructure.Configuration
{
    public static class ConfigurationProvider
    {
        public static IAppConfiguration Configuration { get; private set; }

        private const string SETTINGS_FILE = "appsettings.json";

        private static readonly string _basePath;
        private static readonly ConfigurationFileWatcher _fileWatcher;

        static ConfigurationProvider()
        {
            _basePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            _fileWatcher = new ConfigurationFileWatcher(() =>
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

            appConfiguration.Application.InactiveAfter =
                appConfiguration.Application.InactiveAfter == 0 ? 180 : appConfiguration.Application.InactiveAfter;

            appConfiguration.Application.InactiveAfterMs = appConfiguration.Application.InactiveAfter * 1000;

            Configuration = appConfiguration;

            if (attachFileWatcher)
                _fileWatcher.WatchForChanges(
                    SETTINGS_FILE,
                    _basePath);
        }
    }
}
