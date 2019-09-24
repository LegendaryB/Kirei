using CommandLine;

using System.IO;

namespace Kirei.Watchdog
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<WatchdogOptions>(args)
                .WithParsed(options =>
                {
                    if (options.ProcessId == 0)
                        return;

                    if (string.IsNullOrWhiteSpace(options.AppFilePath) || !File.Exists(options.AppFilePath))
                        return;

                    if (string.IsNullOrWhiteSpace(options.AppStateFilePath) || !File.Exists(options.AppStateFilePath))
                        return;

                    var app = new App(
                        options.AppFilePath,
                        options.AppStateFilePath, 
                        options.ProcessId);

                    app.Run();
                });
        }
    }
}
