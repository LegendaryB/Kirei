using System;

namespace Kirei.Application
{
    public interface IInputHandler
    {
        Action Handler { get; set; }

        void Handle();
    }
}
