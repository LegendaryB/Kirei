using Kirei.Native;

using System;
using System.Threading;

namespace Kirei
{
    internal class Input : IDisposable
    {
        public delegate void UserActiveOrInactiveEvent();
        public event UserActiveOrInactiveEvent UserActiveOrInactive;

        private readonly int _inactiveStateInSeconds;

        private Timer _timer;
        private bool hasIconsBeenHidden = false;

        internal Input(int inactiveStateInSeconds = 300)
        {
            _inactiveStateInSeconds = inactiveStateInSeconds * 1000;
        }

        internal void Handle()
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
