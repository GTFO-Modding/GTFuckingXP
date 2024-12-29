using BepInEx.Unity.IL2CPP;

namespace GTFuckingXP.Extensions
{
    internal static class CCWrapper
    {
        public const string PLUGIN_GUID = "CConsole";
        public static readonly bool HasCC;

        static CCWrapper()
        {
            HasCC = IL2CPPChainloader.Instance.Plugins.ContainsKey(PLUGIN_GUID);
        }
    }
}
