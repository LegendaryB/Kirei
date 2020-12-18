using Kirei.SDK;

namespace Kirei.WindowPlugin
{
    internal class PluginMetadata : IPluginMetadata
    {
        public string Author => "throwingbits";

        public string Name => "Window Plugin";

        public string Description => "This plugin is able to minimize/maximize all windows.";

        public string Version => "1.0.0";
    }
}
