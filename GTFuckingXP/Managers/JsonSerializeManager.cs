using System.Text.Json;

namespace GTFuckingXP.Managers
{
    public class JsonSerializeManager
    {
        public static T Deserialize<T>(string json, JsonSerializerOptions options = null)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
