using Kirei.Application.Configuration;

namespace Kirei.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public bool RunOnStartup { get; set; }
        public bool HideDesktopIcons { get; set; }
        public bool HideTaskbar { get; set; }
        public int InactiveStateInMilliseconds { get; set; }
    }
}
