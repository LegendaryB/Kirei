using Kirei.Engine;
using System.Threading.Tasks;

namespace Kirei
{
    internal class App
    {
        private IStateControllerSupervisor _stateSupervisor;

        public App(IStateControllerSupervisor stateSupervisor)
        {
            _stateSupervisor = stateSupervisor;
        }

        internal async Task RunAsync()
        {
        }
    }
}
