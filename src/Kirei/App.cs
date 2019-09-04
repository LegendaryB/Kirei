using Kirei.Application;
using Kirei.Infrastructure.Configuration;

namespace Kirei
{
    internal class App
    {
        private readonly IInstallWizard _installWizard;
        private readonly IDesktop _desktopAPI;
        private readonly IInputHandler _inputHandler;

        public App(IInstallWizard installWizard,
            IDesktop desktopAPI,
            IInputHandler inputHandler)
        {
            _installWizard = installWizard;
            _desktopAPI = desktopAPI;
            _inputHandler = inputHandler;
        }

        internal void Run()
        {
            if (ConfigurationProvider.Configuration.Application.ShouldRunOnStartup)
                _installWizard.RunOnStartup();

            _inputHandler.Handler = OnUserActiveOrInactive;
            _inputHandler.Handle();
        }

        private void OnUserActiveOrInactive()
        {
            if (ConfigurationProvider.Configuration.Actions.HideDesktopIcons)
                _desktopAPI.ToggleIcons();

            if (ConfigurationProvider.Configuration.Actions.HideTaskBar)
                _desktopAPI.ToggleTaskBar();

            if (ConfigurationProvider.Configuration.Actions.HideApplicationWindows)
                _desktopAPI.ToggleWindows();
        }
    }
}
