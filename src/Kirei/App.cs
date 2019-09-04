using Kirei.Application;
using Kirei.Application.Configuration;

namespace Kirei
{
    internal class App
    {
        private readonly IAppConfigurationProvider _appConfigurationProvider;
        private readonly IInstallWizard _installWizard;
        private readonly IDesktop _desktopAPI;
        private readonly IInputHandler _inputHandler;

        public App(IAppConfigurationProvider appConfigurationProvider,
            IInstallWizard installWizard,
            IDesktop desktopAPI,
            IInputHandler inputHandler)
        {
            _appConfigurationProvider = appConfigurationProvider;
            _installWizard = installWizard;
            _desktopAPI = desktopAPI;
            _inputHandler = inputHandler;
        }

        internal void Run()
        {
            if (_appConfigurationProvider.Configuration.RunOnStartup)
                _installWizard.RunOnStartup();

            _inputHandler.Handler = OnUserActiveOrInactive;
            _inputHandler.Handle();
        }

        private void OnUserActiveOrInactive()
        {
            if (_appConfigurationProvider.Configuration.HideDesktopIcons)
                _desktopAPI.ToggleIcons();

            if (_appConfigurationProvider.Configuration.SetAutoHideTaskBar)
                _desktopAPI.ToggleTaskBar();

            if (_appConfigurationProvider.Configuration.MinimizeAllApplications)
                _desktopAPI.ToggleWindows();
        }
    }
}
