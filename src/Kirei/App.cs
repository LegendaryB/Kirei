using Kirei.Application;
using Kirei.Application.Configuration;

using System;

namespace Kirei
{
    internal class App
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IInstallWizard _installWizard;
        private readonly IDesktop _desktopAPI;
        private readonly IInputHandler _inputHandler;

        public App(IAppConfiguration appConfiguration,
            IInstallWizard installWizard,
            IDesktop desktopAPI,
            IInputHandler inputHandler)
        {
            _appConfiguration = appConfiguration;
            _installWizard = installWizard;
            _desktopAPI = desktopAPI;
            _inputHandler = inputHandler;
        }

        internal void Run()
        {
            if (_appConfiguration.RunOnStartup)
                _installWizard.RunOnStartup();

            _inputHandler.Handler = OnUserActiveOrInactive;
            _inputHandler.Handle();
        }

        private void OnUserActiveOrInactive()
        {
            if (_appConfiguration.HideDesktopIcons)
                _desktopAPI.ToggleIcons();

            if (_appConfiguration.SetAutoHideTaskBar)
                _desktopAPI.ToggleTaskBar();

            if (_appConfiguration.MinimizeAllApplications)
                _desktopAPI.ToggleWindows();
        }
    }
}
