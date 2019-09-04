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
            if (AppConfigurationProvider.Configuration.RunOnStartup)
                _installWizard.RunOnStartup();

            _inputHandler.Handler = OnUserActiveOrInactive;
            _inputHandler.Handle();
        }

        private void OnUserActiveOrInactive()
        {
            if (AppConfigurationProvider.Configuration.HideDesktopIcons)
                _desktopAPI.ToggleIcons();

            if (AppConfigurationProvider.Configuration.SetAutoHideTaskBar)
                _desktopAPI.ToggleTaskBar();

            if (AppConfigurationProvider.Configuration.MinimizeAllApplications)
                _desktopAPI.ToggleWindows();
        }
    }
}
