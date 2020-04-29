namespace Kirei.Engine
{   
    public abstract class StateControllerBase
    {
        protected enum VisualState
        {
            Visible,
            Hidden
        }

        private VisualState _state;

        protected VisualState State 
        {
            get => _state;
            set
            {               
                _state = value;
                OnVisualStateChanged();                
            }
        }

        public void SetVisible() => State = VisualState.Visible;
        public void SetHidden() => State = VisualState.Hidden;

        protected abstract void OnAppearing();
        protected abstract void OnDisappearing();

        private void OnVisualStateChanged()
        {
            if (_state == VisualState.Visible)
                OnAppearing();
            else
                OnDisappearing();
        }
    }
}
