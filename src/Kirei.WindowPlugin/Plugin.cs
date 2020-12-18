using Kirei.SDK;
using Kirei.WindowPlugin.COM;

using System.Threading.Tasks;

namespace Kirei.WindowPlugin
{
    public sealed class Plugin : IPlugin
    {
        private readonly ShellClass _shell;

        public IPluginMetadata Metadata { get; }

        public Plugin()
        {
            _shell = new ShellClass();

            Metadata = new PluginMetadata();
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task OnActiveAsync()
        {
            _shell.UndoMinimizeAll();

            return Task.CompletedTask;
        }

        public Task OnIdleAsync()
        {
            _shell.MinimizeAll();

            return Task.CompletedTask;
        }       

        public void Dispose()
        {
            _shell.Dispose();
        }
    }
}
