using Kirei.Configuration;

using System;

namespace Kirei
{
    internal class Application : IDisposable
    {
        private AppConfiguration _config;
        private Desktop _desktop;
        private Input _input;

        public Application() => Initialize();

        internal void Run()
        {
            _input.UserActiveOrInactive += OnUserActiveOrInactive;
            _input.Handle();
        }

        private void Initialize()
        {
            _config = AppConfigurationProvider.Load();

            _desktop = new Desktop();
            _input = new Input(_config.InactiveStateInSeconds);
        }

        private void OnUserActiveOrInactive()
        {
            if (_config.HideDesktopIcons)
                _desktop.ToggleIcons();

            if (_config.HideTaskbar)
                _desktop.ToggleTaskbar();
        }

        public void Dispose()
        {
            _input.UserActiveOrInactive -= OnUserActiveOrInactive;
            _input.Dispose();
            _input = null;

            _desktop = null;
            _config = null;
        }
    }
}
