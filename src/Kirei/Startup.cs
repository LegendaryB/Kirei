using Calamity;

using Kirei.Configuration;
using Kirei.SDK;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kirei
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private AppOptions _options;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _options = GetOptions(services);

            RegisterPlugins(services);
        }

        private void RegisterPlugins(IServiceCollection services)
        {
            foreach (var pluginAssemblyPath in _options.Plugins)
            {
                var loader = PluginLoaderFactory.CreateLoaderFor<IPlugin>(pluginAssemblyPath);
                services.AddSingleton(loader.Build());
            }
        }

        private AppOptions GetOptions(IServiceCollection services)
        {
            var options = new AppOptions();
            Configuration.Bind("App", options);

            services.Configure<AppOptions>(Configuration.GetSection("App"));

            return options;
        }
    }
}
