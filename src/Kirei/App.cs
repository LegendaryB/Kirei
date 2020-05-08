using System.Runtime.Loader;
using System.Threading.Tasks;

namespace Kirei
{
    internal class App
    {
        private readonly IWindowManager _windowManager;

        public App(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        internal async Task RunAsync()
        {
            _windowManager.HideChildren();
            await Task.Delay(5000);
            _windowManager.ShowChildren();
        }
    }
}
