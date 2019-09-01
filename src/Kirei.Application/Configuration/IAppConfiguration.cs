namespace Kirei.Application.Configuration
{
    public interface IAppConfiguration
    {
        bool RunOnStartup { get; set; }
        bool HideDesktopIcons { get; set; }
        bool HideTaskbar { get; set; }
        bool MinimizeAllApplications { get; set; }
        long InactiveStateInMilliseconds { get; set; }
        int InactiveStateInSeconds { get; set; }
    }
}
