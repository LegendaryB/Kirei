using Kirei.Application.Configuration;

namespace Kirei.Domain.Configuration
{
    public class ActionsSection : IActionsSection
    {
        public bool HideDesktopIcons { get; set; }
        public bool HideTaskBar { get; set; }
        public bool HideApplicationWindows { get; set; }
    }
}
