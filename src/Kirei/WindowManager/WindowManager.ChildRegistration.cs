namespace Kirei
{
    internal sealed partial class WindowManager
    {
        internal class ChildRegistration
        {
            internal VisualState State { get; set; }
            internal IWindowManagerChild Child { get; set; }

            internal ChildRegistration(IWindowManagerChild child)
            {
                Child = child;
            }
        }
    }
}
