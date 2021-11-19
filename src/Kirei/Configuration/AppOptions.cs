using System.Collections.Generic;

namespace Kirei.Configuration
{
    public class AppOptions
    {
        public SupervisorOptions Supervisor { get; set; }
        public List<string> Plugins { get; set; }
    }
}
