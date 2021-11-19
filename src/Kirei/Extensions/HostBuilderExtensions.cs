using Microsoft.Extensions.Hosting;

namespace Kirei.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseStartup(this IHostBuilder builder)
        {
            builder.ConfigureServices((ctx, serviceCollection) =>
            {
                var instance = new Startup(ctx.Configuration);
                instance.ConfigureServices(serviceCollection);
            });

            return builder;
        }
    }
}
