using Kirei.Application;
using Kirei.Application.Configuration;
using Kirei.Configuration;
using Kirei.Infrastructure;
using Kirei.Infrastructure.DesktopAPI;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace Kirei
{
    public class Program
    {
        public static void Main()
        {
            var appConfiguration = AppConfigurationProvider
                .Load();

            var serviceProvider = ConfigureServices(appConfiguration);

            var app = serviceProvider.GetService<App>();
            app.Run();

            Console.ReadLine();
        }

        private static ServiceProvider ConfigureServices(IAppConfiguration appConfiguration)
        {
            return new ServiceCollection()
                .AddSingleton(appConfiguration)
                .AddSingleton<IInstallWizard, InstallWizard>()
                .AddSingleton<IDesktop, Desktop>()
                .AddSingleton<IInputHandler, InputHandler>()
                .AddSingleton<App>()
                .BuildServiceProvider();
        }
    }
}