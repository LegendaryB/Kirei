using Kirei.Application;
using Kirei.Application.System;
using Kirei.Application.System.Desktop;
using Kirei.Application.System.InputProcessing;
using Kirei.Infrastructure;
using Kirei.Infrastructure.System;
using Kirei.Infrastructure.System.Desktop;
using Kirei.Infrastructure.System.InputProcessing;

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
                .AddSingleton<IHibernationService, HibernationService>()
                .AddSingleton<App>()
                .BuildServiceProvider();
        }
    }
}