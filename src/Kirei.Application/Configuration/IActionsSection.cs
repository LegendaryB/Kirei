namespace Kirei.Application.Configuration
{
    public interface IActionsSection
    {
        bool HideDesktopIcons { get; set; }
        bool HideTaskBar { get; set; }
        bool HideApplicationWindows { get; set; }
    }
}