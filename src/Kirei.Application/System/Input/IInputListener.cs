using System;

namespace Kirei.Application.System.Input
{
    public interface IInputListener
    {
        void Listen(IInputActionMapper inputActionMapper);
    }
}
