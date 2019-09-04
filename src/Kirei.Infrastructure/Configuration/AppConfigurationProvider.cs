using Kirei.Application.Configuration;
using Kirei.Domain.Configuration;

using Microsoft.Extensions.Configuration;

using System;
using System.IO;

namespace Kirei.Configuration
{
    public static class AppConfigurationProvider
    {
        public static IAppConfiguration Load()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            var appConfiguration = configuration.Get<AppConfiguration>();

            appConfiguration.InactiveStateInSeconds =
                appConfiguration.InactiveStateInSeconds == 0 ? 180 : appConfiguration.InactiveStateInSeconds;

            appConfiguration.InactiveStateInMilliseconds = appConfiguration.InactiveStateInSeconds * 1000;

            return appConfiguration;
        }
    }
}
