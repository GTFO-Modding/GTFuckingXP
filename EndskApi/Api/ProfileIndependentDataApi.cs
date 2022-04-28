using System;
using System.IO;
using System.Text.Json;

namespace EndskApi.Api
{
    public static class ProfileIndependentDataApi
    {
        private static readonly string _localLowPath;

        static ProfileIndependentDataApi()
        {
            string localLowPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            _localLowPath = Path.Combine(localLowPath, "10 Chambers Collective", "Mods");

            if(!Directory.Exists(_localLowPath))
            {
                Directory.CreateDirectory(_localLowPath);
            }
        }

        public static T Load<T>(string fileName, JsonSerializerOptions option = null) where T : new()
        {
            if(TryLoadFromCache<T>(fileName, out T cacheObj))
            {
                return cacheObj;
            }

            if (option == null)
            {
                option = new JsonSerializerOptions()
                {
                    IncludeFields = false,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
            }

            if (File.Exists(CreatePath(fileName)))
            {
                return JsonSerializer.Deserialize<T>(File.ReadAllText(CreatePath(fileName)), option);
            }

            return new T();
        }

        public static void Save(object obj, string fileName, JsonSerializerOptions option = null)
        {
            SaveIntoCache(fileName, obj);
            if (option == null)
            {
                option = new JsonSerializerOptions()
                {
                    IncludeFields = false,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
            }

            File.WriteAllText(CreatePath(fileName), JsonSerializer.Serialize(obj, option));
        }

        internal static bool TryLoadFromCache<T>(string fileName, out T cachedObj)
        {
            return CacheApi.TryGetInformation(fileName, out cachedObj, "ProfileIndependentApi", false);
        }

        internal static void SaveIntoCache(string fileName, object obj)
        {
            CacheApi.SaveInformation(fileName, obj, "ProfileIndependentApi");
        }

        private static string CreatePath(string fileName)
        {
            if(fileName.EndsWith(".json"))
            {
                return Path.Combine(_localLowPath, fileName);
            }
            else
            {
                return Path.Combine(_localLowPath, $"{fileName}.json");
            }
        }
    }
}
