using System;
using System.Threading.Tasks;

namespace Kirei.SDK
{
    public interface IPluginMetadata
    {
        string Author { get; }
        string Name { get; }
        string Description { get; }
        string Version { get; }
    }

    public interface IPlugin : IDisposable
    {
        IPluginMetadata Metadata { get; }

        /// <summary>
        /// Invoked by the Kirei plugin runtime when the plugin instance is created the
        /// first time
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Invoked by the Kirei plugin runtime when the current user state changes
        /// from idle to active.
        /// </summary>
        Task OnActiveAsync();

        /// <summary>
        /// Invoked by the Kirei plugin runtime when the current user state changes
        /// from active to idle.
        /// </summary>
        Task OnIdleAsync();
    }
}
