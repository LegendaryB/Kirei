namespace Kirei.Application.Configuration
{
    public interface IAppConfiguration
    {
        bool HideDesktopIcons { get; set; }
        bool HideTaskbar { get; set; }
        int InactiveStateInSeconds { get; set; }
    }
}
