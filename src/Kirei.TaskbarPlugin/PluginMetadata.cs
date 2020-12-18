using Kirei.SDK;

namespace Kirei.TaskbarPlugin
{
    internal class PluginMetadata : IPluginMetadata
    {
        public string Author => "throwingbits";

        public string Name => "Taskbar Plugin";

        public string Description => "This plugin toggles the visibility of the windows taskbar.";

        public string Version => "1.0.0";
    }
}
