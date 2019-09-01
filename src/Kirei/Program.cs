using Kirei.Application;
using Kirei.Application.Configuration;
using Kirei.Configuration;
using Kirei.Infrastructure;

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

            using (var app = serviceProvider.GetService<App>())
            {
                app.Run();
            }

            Console.ReadLine();
        }

        private static ServiceProvider ConfigureServices(IAppConfiguration appConfiguration)
        {
            return new ServiceCollection()
                .AddSingleton(appConfiguration)
                .AddSingleton<IDesktopAPI, DesktopAPI>()
                .AddSingleton<IInputHandler, InputHandler>()
                .AddSingleton<App>()
                .BuildServiceProvider();
        }
    }
}