using EndskApi.Api;

namespace XpExpansions.Extensions
{
    public static class CacheApiWrapper
    {
        internal static string ExtensionCacheName = "XpExtensions";
        private const string _folderPath = "FolderPath";

        public static void SetFolderPath(string path)
        {
            CacheApi.SaveInformation(_folderPath, path, ExtensionCacheName);
        }

        public static string GetFolderPath()
        {
            return CacheApi.GetInformation<string>(_folderPath, ExtensionCacheName);
        }
    }
}
