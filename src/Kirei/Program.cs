using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.IO;
using System.Threading.Tasks;

namespace Kirei
{
    class Program
    {
        public static async Task Main()
        {
            var taskbar = new TaskbarStateHandler();
            taskbar.SetHidden();
            await Task.Delay(5000);
            taskbar.SetVisible();

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
