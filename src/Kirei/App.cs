using Kirei.Application;
using Kirei.Application.Desktop;
using Kirei.Application.Input;
using Kirei.Infrastructure.Configuration;

namespace Kirei
{
    internal class App
    {
        private readonly IInstallWizard _installWizard;        
        private readonly IInputListener _inputListener;
        private readonly IInputActionMapper _inputActionMapper;
        private readonly IDesktopService _desktopAPI;

        public App(IInstallWizard installWizard,
            IInputListener inputListener,
            IInputActionMapper inputActionMapper,
            IDesktopService desktopAPI)
        {
            _installWizard = installWizard;            
            _inputListener = inputListener;
            _inputActionMapper = inputActionMapper;
            _desktopAPI = desktopAPI;
        }

        internal void Run()
        {
            if (ConfigurationProvider.Configuration.Application.ShouldRunOnStartup)
                _installWizard.RunOnStartup();

            var cfg = ConfigurationProvider
                .Configuration
                .Actions;

            _inputActionMapper.RegisterAction(
                _desktopAPI.ToggleIcons, 
                () => cfg.HideDesktopIcons);

            _inputActionMapper.RegisterAction(
                _desktopAPI.ToggleTaskBar,
                () => cfg.HideTaskBar);

            _inputActionMapper.RegisterAction(
                _desktopAPI.ToggleWindows,
                () => cfg.HideApplicationWindows);

            _inputListener.Listen(_inputActionMapper);
        }
    }
}
