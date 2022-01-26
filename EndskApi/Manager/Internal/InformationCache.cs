using System.Collections.Generic;

namespace EndskApi.Manager.Internal
{
    internal class InformationCache
    {
        private readonly Dictionary<string, Dictionary<object, object>> _cache;

        public InformationCache()
        {
            _cache = new Dictionary<string,Dictionary<object, object>>();
        }

        public static InformationCache Instance { get; } = new InformationCache();

        public void SaveInformation(object key, object info, string mod)
        {
            GetCacheOfMod(mod)[key] = info;
        }

        public T GetInformation<T>(object key, string mod)
        {
            if (GetCacheOfMod(mod).TryGetValue(key, out var value))
            {
                return (T)value;
            }

            LogManager.Error($"There was no information with the key {key}");
            throw new KeyNotFoundException($"There was no information with the key {key}!");
        }

        public bool TryGetInformation<T>(object key, out T info, string mod, bool logNotFound = true)
        {
            if (GetCacheOfMod(mod).TryGetValue(key, out var value))
            {
                info = (T)value;
                return true;
            }

            if (logNotFound)
            {
                LogManager.Warn($"There was no informaiton with the key {key}");
            }

            info = default;
            return false;
        }

        public void RemoveInformation(object key, string mod)
        {
            if(TryGetCacheOfMod(mod, out var cache))
            {
                cache.Remove(key);
            }
        }

        public bool ContainsKey(object key, string mod)
        {
            return TryGetCacheOfMod(mod, out var cache) && 
                cache.ContainsKey(key);
        }

        private Dictionary<object, object> GetCacheOfMod(string mod)
        {
            if (!_cache.TryGetValue(mod, out var value))
            {
                value = new Dictionary<object, object>();
                _cache[mod] = value;
            }

            return value;
        }

        private bool TryGetCacheOfMod(string mod, out Dictionary<object, object> cache)
        {
           return _cache.TryGetValue(mod, out cache);
        }
    }
}
