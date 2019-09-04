using System;

namespace Kirei.Application.Configuration
{
    public interface IAppConfigurationFileWatcher : 
        IDisposable
    {
        void WatchForChanges(
            string file,
            string basePath);
    }
}
