using Kirei.Application;
using Kirei.Application.Configuration;

using System;

namespace Kirei
{
    internal class App : IDisposable
    {
        private IAppConfiguration _appConfiguration;
        private IDesktop _desktopAPI;
        private IInputHandler _inputHandler;

        public App(IAppConfiguration appConfiguration,
            IDesktop desktopAPI,
            IInputHandler inputHandler)
        {
            _appConfiguration = appConfiguration;
            _desktopAPI = desktopAPI;
            _inputHandler = inputHandler;
        }

        internal void Run()
        {
            _inputHandler.Handler = OnUserActiveOrInactive;
            _inputHandler.Handle();
        }

        private void OnUserActiveOrInactive()
        {
            if (_appConfiguration.HideDesktopIcons)
                _desktopAPI.ToggleIcons();

            if (_appConfiguration.HideTaskbar)
                _desktopAPI.ToggleTaskBar();

            if (_appConfiguration.MinimizeAllApplications)
                _desktopAPI.ToggleWindows();
        }

        public void Dispose()
        {
            _inputHandler = null;
            _desktopAPI = null;
            _appConfiguration = null;
        }
    }
}
