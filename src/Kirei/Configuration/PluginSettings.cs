using System.Text.Json.Serialization;

namespace Kirei.Configuration
{
    public class PluginSettings
    {
        /*"autoload": true,
    "location": "",
    "loadlist": [
      ""
    ]*/

        [JsonPropertyName("autoload")]
        public bool AutoloadPlugins { get; set; }

        [JsonPropertyName("location")]
        public string PluginDirectory { get; set; }


    }
}
