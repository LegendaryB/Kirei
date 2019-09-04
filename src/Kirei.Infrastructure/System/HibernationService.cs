using Kirei.Application.System;
using Kirei.Domain.Native.Enums;
using Kirei.Infrastructure.Native;

namespace Kirei.Infrastructure.System
{
    public class HibernationService : IHibernationService
    {
        public void PreventSleep() =>
            Kernel32.SetThreadExecutionState(ExecutionStates.ES_DISPLAY_REQUIRED | ExecutionStates.ES_CONTINUOUS);
    }
}
