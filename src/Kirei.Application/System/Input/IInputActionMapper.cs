using System;

namespace Kirei.Application.System.Input
{
    public interface IInputActionMapper
    {
        void HandleInput();
        void RegisterAction(Action action, Func<bool> condition);
    }
}
