using System.Threading.Tasks;

namespace Kirei.SDK
{
    public interface IPlugin
    {
        Task InitializeAsync();

        /// <summary>
        /// Invoked by the main application when user activity is detected.
        /// </summary>
        /// <returns></returns>
        Task OnActivityAsync();

        /// <summary>
        /// Invoked by the main application when user idle is detected.
        /// </summary>
        /// <returns></returns>
        Task OnIdleAsync();
    }
}
