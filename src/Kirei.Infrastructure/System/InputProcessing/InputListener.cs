using Kirei.Application.System.InputProcessing;
using Kirei.Infrastructure.Configuration;

using NeatInput;
using NeatInput.Domain.Processing;

using System;
using System.Threading;

namespace Kirei.Infrastructure.System.InputProcessing
{
    public class InputListener :
        IInputListener
    {
        private InputProvider _inputProvider;
        private IInputActionMapper _inputActionMapper;

        private DateTime lastInputReceivedAt;
        private bool hasIconsBeenHidden = false;        

        public void Listen(IInputActionMapper inputActionMapper)
        {
            _inputProvider = new InputProvider();
            _inputActionMapper = inputActionMapper;

            lastInputReceivedAt = DateTime.Now;

            _inputProvider.InputReceived += OnInputReceived;

            var inactiveAfterMs = ConfigurationProvider.Configuration.Application.InactiveAfterMs;
            var inputPollingRateMs = ConfigurationProvider.Configuration.Application.InputPollingRate;

            while (true)
            {
                var lastInputInMilliseconds = DateTime.Now.Subtract(lastInputReceivedAt).TotalMilliseconds;                

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

                Thread.Sleep(inputPollingRateMs);
            }
        }

        private void OnInputReceived(Input input)
        {
            lastInputReceivedAt = DateTime.Now;
        }
    }
}
