using System;

namespace Kirei.Application.Configuration
{
    public interface IAppConfigurationProvider : 
        IDisposable
    {
        IAppConfiguration Configuration { get; }
    }
}
