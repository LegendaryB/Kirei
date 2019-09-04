using Kirei.Application.Configuration;

namespace Kirei.Domain.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public bool RunOnStartup { get; set; }
        public bool HideDesktopIcons { get; set; }
        public bool SetAutoHideTaskBar { get; set; }
        public bool MinimizeAllApplications { get; set; }
        public long InactiveStateInMilliseconds { get; set; }
        public int InactiveStateInSeconds { get; set; }
    }
}
