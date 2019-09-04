using Kirei.Application;

namespace Kirei.Infrastructure.DesktopAPI
{
    public class Desktop :
        IDesktop
    {
        private readonly Shell _shell;
        private readonly TaskBar _taskBar;

        private bool windowsMinimized = false;
        private bool taskBarHidden = false;
        private bool desktopIconsHidden = false;

        public Desktop()
        {
            _shell = new Shell();
            _taskBar = new TaskBar();
        }

        public void ToggleTaskBar()
        {
            if (taskBarHidden)
                _taskBar.Show();
            else
                _taskBar.Hide();

            taskBarHidden = !taskBarHidden;
        }

        public void ToggleIcons()
        {
            if (desktopIconsHidden)
                _shell.ShowDesktopIcons();
            else
                _shell.HideDesktopIcons();

            desktopIconsHidden = !taskBarHidden;
        }

        public void ToggleWindows()
        {
            if (windowsMinimized)
                _shell.UndoMinimizeWindows();
            else
                _shell.MinimizeWindows();

            windowsMinimized = !windowsMinimized;
        }
    }
}
