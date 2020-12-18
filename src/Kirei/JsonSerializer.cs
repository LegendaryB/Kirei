using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

using Serializer = System.Text.Json.JsonSerializer;

namespace Kirei
{
    internal static class JsonSerializer
    {
        private static readonly JsonSerializerOptions _options =
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        internal static async Task<T> DeserializeAsync<T>(string path)
            where T : class
        {
            if (!File.Exists(path))
                return default;

            using (var fs = File.OpenRead("appsettings.json"))
            {
                return await Serializer.DeserializeAsync<T>(fs, _options);
            }
        }
    }
}
