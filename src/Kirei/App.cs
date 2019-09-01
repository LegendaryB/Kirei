using Kirei.Application;
using Kirei.Application.Configuration;

using System;

namespace Kirei
{
    internal class App : IDisposable
    {
        private IAppConfiguration _config;
        private IDesktopAPI _desktopAPI;
        private IInputHandler _inputHandler;

        public App(IAppConfiguration appConfiguration,
            IDesktopAPI desktopAPI,
            IInputHandler inputHandler)
        {
            _config = appConfiguration;
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
            if (_config.HideDesktopIcons)
                _desktopAPI.ToggleIcons();

            if (_config.HideTaskbar)
                _desktopAPI.ToggleTaskbar();
        }

        public void Dispose()
        {
            _inputHandler = null;
            _desktopAPI = null;
            _config = null;
        }
    }
}
