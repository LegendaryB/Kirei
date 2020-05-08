using System.Collections.Generic;
using System.Linq;

namespace Kirei
{
    internal sealed partial class WindowManager : 
        IWindowManager
    {
        private readonly List<ChildRegistration> _childrenRegistration =
            new List<ChildRegistration>();

        public WindowManager() { }

        public WindowManager(IEnumerable<IWindowManagerChild> modules)
            : this()
        {
            _childrenRegistration.AddRange(modules.Select(
                m => new ChildRegistration(m)));
        }

        public void ShowChildren()
        {
            foreach (var registration in _childrenRegistration)
            {
                if (registration.State == VisualState.Visible)
                    continue;

                registration.Child.SetVisible();
                registration.State = VisualState.Visible;
            }
        }
        
        public void HideChildren()
        {
            foreach (var registration in _childrenRegistration)
            {
                if (registration.State == VisualState.Hidden)
                    continue;

                registration.Child.SetHidden();
                registration.State = VisualState.Hidden;
            }
        }
    }
}
