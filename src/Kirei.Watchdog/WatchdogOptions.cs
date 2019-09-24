using CommandLine;

namespace Kirei.Watchdog
{
    public class WatchdogOptions
    {
        [Option("pid", Required = true)]
        public int ProcessId { get; set; }

        [Option("appFilePath", Required = true)]
        public string AppFilePath { get; set; }

        [Option("appStateFilePath", Required = true)]
        public string AppStateFilePath { get; set; }
    }
}
