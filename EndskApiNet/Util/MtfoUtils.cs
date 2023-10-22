using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Unity.IL2CPP;
using EndskApi.Manager;
using System;
using System.Linq;
using System.Reflection;

namespace EndskApi.Util
{
    //This class was written by Kasuromi in the "CustomBoosters" Mod.
    public static class MtfoUtils
    {
        /// <summary>
        /// Gets the path to the CustomFolder MTFO uses.
        /// </summary>
        public static string CustomPath { get; private set; } = string.Empty;
        public static string Version { get; private set; } = string.Empty;

        /// <summary>
        /// Gets if the mtfo plugin exists.
        /// </summary>
        public static bool PluginExists { get; private set; } = false;
        static MtfoUtils()
        {
            if (!IL2CPPChainloader.Instance.Plugins.TryGetValue("com.dak.MTFO", out PluginInfo info)) return;
            PluginExists = true;
            try
            {
                Assembly mtfoAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((x) => !x.IsDynamic && x.Location == info.Location);
                if (mtfoAssembly == null) throw new Exception($"couldn't locate the MTFO assembly");
                Type[] mtfoTypes = mtfoAssembly.GetTypes();
                Type confManagerType = mtfoTypes.FirstOrDefault((x) => x.Name == "ConfigManager");
                Type mtfoType = mtfoTypes.FirstOrDefault((x) => x.Name == "MTFO");
                if (mtfoType == null) throw new Exception($"couldn't locate MTFO's EntryPoint");
                if (confManagerType == null) throw new Exception($"couldn't locate MTFO's ConfigManager");
                FieldInfo versionField = mtfoType.GetField("VERSION", BindingFlags.Public | BindingFlags.Static);
                FieldInfo customPathField = confManagerType.GetField("CustomPath", BindingFlags.Public | BindingFlags.Static);
                if (versionField == null) throw new Exception($"couldn't locate MTFO's Version");
                if (customPathField == null) throw new Exception($"couldn't locate MTFO's CustomPath");
                CustomPath = (string)customPathField.GetValue(null);
                Version = (string)versionField.GetValue(null);

                Type hotReloaderType = mtfoTypes.FirstOrDefault((x) => x.Name == "HotReloader");
                //BepInExLoader.Harmony.Patch(hotReloaderType.GetMethod("ReloadData"), null, new HarmonyLib.HarmonyMethod(typeof(HotRealoaderPatch).GetMethod(nameof(HotRealoaderPatch.HotRealoadPostfix))));
            }
            catch (Exception thisIsSomeGoodStuffKasuromi)
            {
                LogManager.Error(thisIsSomeGoodStuffKasuromi.ToString());
            }
        }
    }
}
