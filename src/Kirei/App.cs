using Kirei.Extensibility;
using Kirei.SDK;

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Kirei
{
    internal class App
    {
        internal async Task RunAsync()
        {
            var path = @"C:\Users\danie\source\repos\Kirei\src\Kirei.TaskbarPlugin\bin\Debug\netstandard2.1\Kirei.TaskbarPlugin.dll";
            var loadContext = new PluginLoadContext(path);

            var assembly = loadContext.LoadFromAssemblyName(new AssemblyName(
                Path.GetFileNameWithoutExtension(path)));

            var pluginType = assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(IPlugin).IsAssignableFrom(t));

            var x = Activator.CreateInstance(pluginType) as IPlugin;
            await x.InitializeAsync();
        }
    }
}
