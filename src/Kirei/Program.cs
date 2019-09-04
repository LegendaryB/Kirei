using Kirei.Application;
using Kirei.Application.Input;
using Kirei.Infrastructure;
using Kirei.Infrastructure.Desktop;
using Kirei.Infrastructure.Input;

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
                .AddSingleton<IDesktopService, DesktopService>()
                .AddSingleton<IInputActionMapper, InputActionMapper>()
                .AddSingleton<IInputListener, InputListener>()
                .AddSingleton<App>()
                .BuildServiceProvider();
        }
    }
}