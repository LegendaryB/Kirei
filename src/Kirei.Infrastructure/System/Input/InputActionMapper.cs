using Kirei.Application.System.Input;

using System;
using System.Collections.Generic;

namespace Kirei.Infrastructure.System.Input
{
    public class InputActionMapper : IInputActionMapper
    {
        private readonly List<Action> _actionsOnInput;

        public InputActionMapper()
        {
            _actionsOnInput = new List<Action>();
        }

        public void HandleInput()
        {
            foreach (var action in _actionsOnInput)
                action?.Invoke();
        }

        public void RegisterAction(
            Action action,
            Func<bool> condition)
        {
            if (action == null || condition?.Invoke() != true)
                return;

            _actionsOnInput.Add(action);
        }
    }
}
