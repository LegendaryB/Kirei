using System;
using System.Threading.Tasks;

namespace Kirei.SDK
{
    public interface IPlugin : IDisposable
    {
        /// <summary>
        /// Contains some metadata informations about the plugin. For example the authors name.
        /// </summary>
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
