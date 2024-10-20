using System.Text.Json;

namespace GTFuckingXP.Extensions.Information.Level.Json
{
    internal static class BuffJson
    {
        private static readonly JsonSerializerOptions _setting = new()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            IgnoreReadOnlyProperties = true,
        };

        static BuffJson()
        {
            _setting.Converters.Add(new CustomBuffConverter());
            _setting.Converters.Add(new SingleBuffConverter());
        }

        public static T? Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, _setting);
        }

        public static string Serialize<T>(T value)
        {
            return JsonSerializer.Serialize(value, _setting);
        }
    }
}
