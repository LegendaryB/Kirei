using Kirei.Application;
using Kirei.Application.Configuration;
using Kirei.Infrastructure.Native;

using System;
using System.Threading;

namespace Kirei.Infrastructure
{
    public class Input :
        IInputHandler, 
        IDisposable
    {
        public delegate void UserActiveOrInactiveEvent();
        public event UserActiveOrInactiveEvent UserActiveOrInactive;

        private readonly int _inactiveStateInSeconds;

        private Timer _timer;
        private bool hasIconsBeenHidden = false;

        // todo: replace with appconfigurationprovider
        public Input(IAppConfiguration appConfiguration)
        {
            _inactiveStateInSeconds = appConfiguration.InactiveStateInSeconds;
        }

        public void Handle()
        {
            _timer = new Timer(OnTimerCallback, null, 0, 500);
        }

        private void OnTimerCallback(object state)
        {
            var lastInputInMilliseconds = User32.GetLastInputTimeInMilliseconds();

            if (lastInputInMilliseconds >= _inactiveStateInSeconds && !hasIconsBeenHidden)
            {
                UserActiveOrInactive?.Invoke();
                hasIconsBeenHidden = true;
            }
            else if (lastInputInMilliseconds < _inactiveStateInSeconds && hasIconsBeenHidden)
            {
                UserActiveOrInactive?.Invoke();
                hasIconsBeenHidden = false;
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
