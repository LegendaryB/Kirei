using System;

namespace Kirei.Application
{
    public interface IInputHandler
    {
        Action Handler { get; set; }
        bool IgnoreNextMessage { get; set; }

        void Handle();
    }
}
