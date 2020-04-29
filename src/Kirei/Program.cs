using Kirei.Engine;

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
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<App>().RunAsync();
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var config = LoadConfiguration();

            services.AddSingleton(config);
            services.AddSingleton<IStateControllerSupervisor, StateControllerSupervisor>();

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
