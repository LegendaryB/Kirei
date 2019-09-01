using System;
using System.Threading;

namespace Kirei.Application
{
    public interface IInputHandler
    {
        Action Handler { get; set; }

        void Handle();
    }
}
