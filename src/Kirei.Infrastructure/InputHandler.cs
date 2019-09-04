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
        private readonly IAppConfigurationProvider _appConfigurationProvider;

        private bool hasIconsBeenHidden = false;

        public Action Handler { get; set; }
        public bool IgnoreNextMessage { get; set; }

        public InputHandler(IAppConfigurationProvider appConfigurationProvider)
        {
            _appConfigurationProvider = appConfigurationProvider;
        }

        public void Handle()
        {
            while (true)
            {
                var lastInputInMilliseconds = User32.GetUserIdleTime();

                if (lastInputInMilliseconds >= _appConfigurationProvider.Configuration.InactiveStateInMilliseconds && !hasIconsBeenHidden)
                {
                    Handler?.Invoke();
                    hasIconsBeenHidden = true;
                }
                else if (lastInputInMilliseconds < _appConfigurationProvider.Configuration.InactiveStateInMilliseconds && hasIconsBeenHidden)
                {
                    Handler?.Invoke();
                    hasIconsBeenHidden = false;
                }

                Thread.Sleep(200);
            }
        }
    }
}
