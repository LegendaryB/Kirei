using System;

namespace Kirei.Application.Input
{
    public interface IInputActionMapper
    {
        void HandleInput();
        void RegisterAction(Action action, Func<bool> condition);
    }
}
