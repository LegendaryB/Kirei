using Kirei.Application.System.Input;
using Kirei.Infrastructure.Configuration;
using Kirei.Infrastructure.Native;

using System.Threading;

namespace Kirei.Infrastructure.System.Input
{
    public class InputListener :
        IInputListener
    {
        private IInputActionMapper _inputActionMapper;
        private bool hasIconsBeenHidden = false;

        public void Listen(IInputActionMapper inputActionMapper)
        {
            _inputActionMapper = inputActionMapper;

            while (true)
            {
                var lastInputInMilliseconds = User32.GetUserIdleTime();
                var inactiveAfterMs = ConfigurationProvider.Configuration.Application.InactiveAfterMs;

                if (lastInputInMilliseconds >= inactiveAfterMs && !hasIconsBeenHidden)
                {
                    _inputActionMapper.HandleInput();
                    hasIconsBeenHidden = true;
                }
                else if (lastInputInMilliseconds < inactiveAfterMs && hasIconsBeenHidden)
                {
                    _inputActionMapper.HandleInput();
                    hasIconsBeenHidden = false;
                }                

                Thread.Sleep(ConfigurationProvider.Configuration.Application.InputPollingRate);
            }
        }
    }
}
