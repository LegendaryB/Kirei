using Kirei.Configuration;

using System;
using System.Threading;
using System.Threading.Tasks;

using static Interop;
using static Interop.User32;

namespace Kirei
{
    public class Supervisor
    {
        private enum State
        {
            Active,
            Idle
        }

        private readonly Func<Task> _userActiveFn;
        private readonly Func<Task> _userIdleFn;

        private readonly SupervisorOptions _options;

        private State _state = State.Active;

        public Supervisor(
            SupervisorOptions options,
            Func<Task> userActiveCallback,
            Func<Task> userIdleCallback)
        {
            _options = options;

            _userActiveFn = userActiveCallback;
            _userIdleFn = userIdleCallback;
        }

        public async Task StartAsync(CancellationToken token = default)
        {
            while (!token.IsCancellationRequested)
            {
                var idleTimeSpan = GetIdleTimeSpan();

                if (IsUserActive() && _state == State.Idle)
                {
                    _state = State.Active;
                    await _userActiveFn();
                }
                else if (!IsUserActive() && _state == State.Active)
                {
                    _state = State.Idle;
                    await _userIdleFn();
                }

                await Task.Delay(5000, token);
            }
        }

        private bool IsUserActive()
        {
            var idleTimeSpan = GetIdleTimeSpan();

            return idleTimeSpan.TotalSeconds < _options.IdleTime;
        }

        private TimeSpan GetIdleTimeSpan()
        {
            var plii = LASTINPUTINFO.Create();

            if (!GetLastInputInfo(ref plii))
                return new TimeSpan(0);

            var elapsedTicks = Environment.TickCount - (int)plii.dwTime;

            var idleTime = elapsedTicks > 0 ?
                new TimeSpan(0, 0, 0, 0, elapsedTicks) :
                new TimeSpan(0);

            return idleTime;
        }
    }
}
