using System;

namespace Kirei.Application.System.InputProcessing
{
    public interface IInputListener
    {
        void Listen(IInputActionMapper inputActionMapper);
    }
}
