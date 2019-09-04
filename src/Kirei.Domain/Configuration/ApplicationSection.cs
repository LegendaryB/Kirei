using Kirei.Application.Configuration;

namespace Kirei.Domain.Configuration
{
    public class ApplicationSection : IApplicationSection
    {
        public bool ShouldRunOnStartup { get; set; }
        public long InactiveAfter { get; set; }
        public long InactiveAfterMs { get; set; }

        // ms
        public long InputPollingRate { get; set; }
    }
}
