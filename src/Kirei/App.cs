using Kirei.Configuration;
using Kirei.SDK;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kirei
{
    public class App : IHostedService
    {
        private readonly Supervisor _supervisor;
        private readonly IEnumerable<IPlugin> _plugins;

        public App(
            IOptions<AppOptions> options,
            IEnumerable<IPlugin> plugins)
        {
            _supervisor = new Supervisor(
                options.Value.Supervisor,
                HandleActivityAsync,
                HandleIdleAsync);

            _plugins = plugins;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await InitializePluginsAsync();
            await _supervisor.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }        

        private async Task HandleActivityAsync()
        {
            foreach (var plugin in _plugins)
                await plugin.OnActivityAsync();
        }

        private async Task HandleIdleAsync()
        {
            foreach (var plugin in _plugins)
                await plugin.OnIdleAsync();
        }

        private async Task InitializePluginsAsync()
        {
            foreach (var plugin in _plugins)
                await plugin.InitializeAsync();
        }
    }
}
