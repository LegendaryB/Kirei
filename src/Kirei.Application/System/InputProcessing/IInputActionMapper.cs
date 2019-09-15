using System;

namespace Kirei.Application.System.InputProcessing
{
    public interface IInputActionMapper
    {
        void HandleInput();
        void RegisterAction(Action action, Func<bool> condition);
    }
}
