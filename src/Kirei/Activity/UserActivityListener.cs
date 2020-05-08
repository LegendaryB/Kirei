using NeatInput.Windows;
using NeatInput.Windows.Events;

using System;

namespace Kirei
{
    internal class UserActivityListener :
        IMouseEventReceiver,
        IKeyboardEventReceiver
    {
        private DateTimeOffset _lastActivityTime;

        public void Receive(KeyboardEvent @event) => _lastActivityTime = DateTimeOffset.Now;
        public void Receive(MouseEvent @event) => _lastActivityTime = DateTimeOffset.Now;
    }
}
