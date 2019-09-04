using System;

namespace Kirei.Application.Input
{
    public interface IInputListener
    {
        void Listen(IInputActionMapper inputActionMapper);
    }
}
