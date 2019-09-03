using Kirei.Application;

using Microsoft.Win32;
using System;
using System.IO;

namespace Kirei.Infrastructure
{
    public class InstallWizard : IInstallWizard
    {
        public void RunOnStartup()
        {
            try
            {
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (var key = baseKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        if (key == null)
                            return;

                        var path = Path.Combine(
                            Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),
                            "Kirei.exe");

                        key.SetValue("Kirei", path);
                    }
                }
            }
            catch { }
        }
    }
}
