namespace Kirei.SDK
{
    public interface IPluginMetadata
    {
        /// <summary>
        /// The author name of the plugin.
        /// </summary>
        string Author { get; }

        /// <summary>
        /// The display name of the plugin.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A short descriptions what this plugin is capable of.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The version number of the plugin.
        /// </summary>
        string Version { get; }
    }
}
