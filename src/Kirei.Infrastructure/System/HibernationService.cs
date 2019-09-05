using Kirei.Application.System;
using Kirei.Domain.Native.Enums;
using Kirei.Infrastructure.Native;

using System.Threading.Tasks;

namespace Kirei.Infrastructure.System
{
    public class HibernationService : IHibernationService
    {
        public void PreventSleep()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Kernel32.SetThreadExecutionState(
                      ExecutionStates.ES_CONTINUOUS |
                      ExecutionStates.ES_DISPLAY_REQUIRED);

                    await Task.Delay(5000);
                }
            });
        }
            
    }
}
