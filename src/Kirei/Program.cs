using Kirei.Application;
using Kirei.Application.Configuration;
using Kirei.Infrastructure;
using Kirei.Infrastructure.DesktopAPI;
using Kirei.Infrastructure.Configuration;

using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Kirei
{
    public class Program
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            var app = serviceProvider.GetService<App>();
            app.Run();
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddMediatR(typeof(AppConfigurationProvider))
                .AddSingleton<IAppConfigurationFileWatcher, AppConfigurationFileWatcher>()
                .AddSingleton<IAppConfigurationProvider, AppConfigurationProvider>()
                .AddSingleton<IInstallWizard, InstallWizard>()
                .AddSingleton<IDesktop, Desktop>()
                .AddSingleton<IInputHandler, InputHandler>()
                .AddSingleton<App>()
                .BuildServiceProvider();
        }
    }
}