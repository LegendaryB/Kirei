namespace Kirei.Domain.Configuration
{
    public class ApplicationSection
    {
        public bool ShouldRunOnStartup { get; set; }
        public long InactiveAfter { get; set; }
        public long InactiveAfterMs { get; set; }
        public int InputPollingRate { get; set; }
    }
}
