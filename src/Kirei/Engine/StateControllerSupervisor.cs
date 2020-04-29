using System;
using System.Collections.Generic;

namespace Kirei.Engine
{
    internal sealed class StateControllerSupervisor : StateControllerBase,
        IStateControllerSupervisor,
        IDisposable
    {
        private readonly List<IStateController> _controllers;

        public StateControllerSupervisor()
        {
            _controllers = new List<IStateController>
            {
                new TaskbarController(),
                new WindowController(),
                new DesktopIconController()
            };
        }

        protected override void OnAppearing()
        {
            foreach (var controller in _controllers)
                controller.SetVisible();
        }

        protected override void OnDisappearing()
        {
            foreach (var controller in _controllers)
                controller.SetHidden();
        }

        public void Dispose()
        {
            //foreach (var controller in _controllers)
            //    if (controller.)
        }
    }
}
