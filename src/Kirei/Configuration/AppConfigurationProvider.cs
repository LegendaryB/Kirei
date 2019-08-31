using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Kirei.Configuration
{
    internal static class AppConfigurationProvider
    {
        internal static AppConfiguration Load()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            var appConfiguration = configuration.Get<AppConfiguration>();

            appConfiguration.InactiveStateInSeconds =
                appConfiguration.InactiveStateInSeconds == 0 ? 240 : appConfiguration.InactiveStateInSeconds;

            return appConfiguration;
        }
    }
}
