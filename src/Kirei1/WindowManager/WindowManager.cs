using System.Collections.Generic;

namespace Kirei
{
    internal partial class WindowManager : 
        IWindowManager
    {
        private readonly Dictionary<IWindowManagerModule, VisualState> _modules;

        //private VisualState _state;

        //private VisualState State
        //{
        //    get => _state;
        //    set
        //    {
        //        _state = value;
        //        OnVisualStateChanged();
        //    }
        //}

        public WindowManager()
        {
            _modules = new Dictionary<IWindowManagerModule, VisualState>();
        }

        public WindowManager(IEnumerable<IWindowManagerModule> modules)
            : this()
        {
            foreach (var module in modules)
                _modules.Add(module, VisualState.Visible);
        }

        //public void SetVisible() => State = VisualState.Visible;
        //public void SetHidden() => State = VisualState.Hidden;

        //protected abstract void OnAppearing();
        //protected abstract void OnDisappearing();

        private void OnVisualStateChanged()
        {
            //if (_state == VisualState.Visible)
            //    OnAppearing();
            //else
            //    OnDisappearing();
        }
    }
}
