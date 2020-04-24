using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using static Interop;

namespace Kirei
{
    class Program
    {
        public static async Task Main()
        {
            var manager = new DesktopIconManager();
            manager.Hide();
            await Task.Delay(1500);
            manager.Show();

            //var taskbar = new TaskbarManager();
            //taskbar.Hide();

            //await Task.Delay(5000);

            //taskbar.Show();

            //var x = User32.GetShellWindow();
            //var name = User32.GetClassName(x);

            //var y = User32.FindWindowEx(
            //    x,
            //    IntPtr.Zero,
            //    "SHELLDLL_DefView",
            //    string.Empty);

            //var z = User32.FindWindowEx(
            //    y,
            //    IntPtr.Zero,
            //    "SysListView32",
            //    "FolderView");

            //User32.ShowWindow(
            //    z,
            //    User32.SW.RESTORE);

            // var z = User32.GetClassName(y);

            //var taskbar = new Taskbar();
            //taskbar.Hide();
            //await Task.Delay(15000);
            //taskbar.Show();

            //var services = ConfigureServices();
            //var serviceProvider = services.BuildServiceProvider();

            //await serviceProvider.GetService<App>().RunAsync();
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);

            services.AddTransient<App>();

            return services;
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
