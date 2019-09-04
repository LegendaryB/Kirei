using Kirei.Application;
using Kirei.Application.System;
using Kirei.Application.System.Desktop;
using Kirei.Application.System.Input;
using Kirei.Infrastructure.Configuration;

namespace Kirei
{
    internal class App
    {
        private readonly IInstallWizard _installWizard;        
        private readonly IInputListener _inputListener;
        private readonly IInputActionMapper _inputActionMapper;
        private readonly IDesktopService _desktopService;
        private readonly IHibernationService _hibernationService;

        public App(IInstallWizard installWizard,
            IInputListener inputListener,
            IInputActionMapper inputActionMapper,
            IDesktopService desktopService,
            IHibernationService hibernationService)
        {
            _installWizard = installWizard;            
            _inputListener = inputListener;
            _inputActionMapper = inputActionMapper;
            _desktopService = desktopService;
            _hibernationService = hibernationService;
        }

        internal void Run()
        {
            if (ConfigurationProvider.Configuration.Application.ShouldRunOnStartup)
                _installWizard.RunOnStartup();

            var cfg = ConfigurationProvider
                .Configuration
                .Actions;

            _inputActionMapper.RegisterAction(
                _desktopService.ToggleIcons, 
                () => cfg.HideDesktopIcons);

            _inputActionMapper.RegisterAction(
                _desktopService.ToggleTaskBar,
                () => cfg.HideTaskBar);

            _inputActionMapper.RegisterAction(
                _desktopService.ToggleWindows,
                () => cfg.HideApplicationWindows);

            _inputActionMapper.RegisterAction(
                _hibernationService.PreventSleep,
                () => cfg.PreventSleep);

            _inputListener.Listen(_inputActionMapper);
        }
    }
}
