using Kirei.Application;
using Kirei.Infrastructure.Configuration;
using Kirei.Infrastructure.Native;

using System;
using System.Threading;

namespace Kirei.Infrastructure
{
    public class InputHandler :
        IInputHandler
    {
        private bool hasIconsBeenHidden = false;

        public Action Handler { get; set; }

        public void Handle()
        {
            while (true)
            {
                var lastInputInMilliseconds = User32.GetUserIdleTime();
                var inactiveAfterMs = ConfigurationProvider.Configuration.Application.InactiveAfterMs;

                if (lastInputInMilliseconds >= inactiveAfterMs && !hasIconsBeenHidden)
                {
                    Handler?.Invoke();
                    hasIconsBeenHidden = true;
                }
                else if (lastInputInMilliseconds < inactiveAfterMs && hasIconsBeenHidden)
                {
                    Handler?.Invoke();
                    hasIconsBeenHidden = false;
                }

                Thread.Sleep(200);
            }
        }
    }
}
