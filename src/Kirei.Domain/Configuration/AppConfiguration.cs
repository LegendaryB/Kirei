using Kirei.Application.Configuration;

namespace Kirei.Domain.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public IApplicationSection Application { get; set; }
        public IActionsSection Actions { get; set; }
    }
}
