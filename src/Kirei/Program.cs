using Kirei.Application;
using Kirei.Infrastructure;
using Kirei.Infrastructure.DesktopAPI;

using Microsoft.Extensions.DependencyInjection;

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
                .AddSingleton<IInstallWizard, InstallWizard>()
                .AddSingleton<IDesktop, Desktop>()
                .AddSingleton<IInputHandler, InputHandler>()
                .AddSingleton<App>()
                .BuildServiceProvider();
        }
    }
}