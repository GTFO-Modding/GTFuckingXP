using EndskApi.Manager.Internal;

namespace EndskApi.Api
{
    /// <summary>
    /// Handles internal workloads with <see cref="InformationCache"/>.
    /// </summary>
    public static class CacheApi
    {
        private const string GlobalCache = "GlobalCache";
        internal const string InternalCache = "EndskApi";

        private static readonly InformationCache _informationCache;

        static CacheApi()
        {
            _informationCache = InformationCache.Instance;
        }

        /// <summary>
        /// Saves <paramref name="info"/> object into the cache for <paramref name="mod"/> with the key <paramref name="key"/>.
        /// </summary>
        public static void SaveInformation(object key, object info, string mod = GlobalCache)
        {
            _informationCache.SaveInformation(key, info, mod);
        }

        public static void SaveInstance<T>(T info, string mod = GlobalCache)
        {
            SaveInformation(typeof(T), info, mod);
        }

        public static T GetInformation<T>(object key, string mod = GlobalCache)
        {
            return _informationCache.GetInformation<T>(key, mod);
        }

        public static T GetInstance<T>(string mod = GlobalCache)
        {
            return GetInformation<T>(typeof(T), mod);
        }

        public static bool TryGetInformation<T>(object key, out T information, string mod = GlobalCache, bool logNotFound = true)
        {
            return _informationCache.TryGetInformation(key, out information, mod, logNotFound);
        }

        public static bool TryGetInstance<T>(out T information, string mod = GlobalCache, bool logNotFound = true)
        {
            return _informationCache.TryGetInformation(typeof(T), out information, mod, logNotFound);
        }

        public static void RemoveInformation(object key, string mod = GlobalCache)
        {
            _informationCache.RemoveInformation(key, mod);
        }

        public static void RemoveInstance<T>(string mod = GlobalCache)
        {
            RemoveInformation(typeof(T), mod);
        }

        public static bool ContainsKey(object key, string mod = GlobalCache)
        {
            return _informationCache.ContainsKey(key, mod);
        }

        public static InformationCache GetInformationCache()
        {
            return _informationCache;
        }
    }
}
