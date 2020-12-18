using Kirei.Configuration;

using Microsoft.Extensions.DependencyInjection;

using System.Threading.Tasks;

namespace Kirei
{
    class Program
    {
        private const string SETTINGS_FILE = "appsettings.json";

        public static async Task Main()
        {
            var services = await ConfigureServicesAsync();
            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider
                .GetService<App>()
                .RunAsync();
        }

        private static async Task<IServiceCollection> ConfigureServicesAsync()
        {
            var services = new ServiceCollection();

            var settings = await JsonSerializer.DeserializeAsync<AppSettings>(
                SETTINGS_FILE);

            services.AddSingleton(settings);
            services.AddSingleton<App>();

            return services;
        }
    }
}
