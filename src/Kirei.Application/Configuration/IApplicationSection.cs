namespace Kirei.Application.Configuration
{
    public interface IApplicationSection
    {
        bool ShouldRunOnStartup { get; set; }
        long InactiveAfter { get; set; }
        long InactiveAfterMs { get; set; }

        // ms
        long InputPollingRate { get; set; }
    }
}