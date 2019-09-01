using Kirei.Application;
using Kirei.Application.Configuration;
using Kirei.Infrastructure.Native;

using System;
using System.Threading;

namespace Kirei.Infrastructure
{
    public class InputHandler :
        IInputHandler
    {
        private readonly IAppConfiguration _appConfiguration;

        private bool hasIconsBeenHidden = false;

        public Action Handler { get; set; }

        public InputHandler(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public void Handle()
        {
            while (true)
            {
                var lastInputInMilliseconds = User32.GetLastInputTimeInMilliseconds();

                if (lastInputInMilliseconds >= _appConfiguration.InactiveStateInMilliseconds && !hasIconsBeenHidden)
                {
                    Handler?.Invoke();
                    hasIconsBeenHidden = true;
                }
                else if (lastInputInMilliseconds < _appConfiguration.InactiveStateInMilliseconds && hasIconsBeenHidden)
                {
                    Handler?.Invoke();
                    hasIconsBeenHidden = false;
                }

                Thread.Sleep(100);
            }
        }
    }
}
