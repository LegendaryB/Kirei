namespace Kirei.Application.Configuration
{
    public interface IAppConfiguration
    {
        bool RunOnStartup { get; set; }
        bool HideDesktopIcons { get; set; }
        bool HideTaskbar { get; set; }
        int InactiveStateInMilliseconds { get; set; }
    }
}
