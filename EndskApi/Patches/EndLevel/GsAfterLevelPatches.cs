using EndskApi.Api;
using HarmonyLib;

namespace EndskApi.Patches.EndLevel
{
    [HarmonyPatch(typeof(GS_AfterLevel))]
    public class GsAfterLevelPatches
    {
        [HarmonyPatch(nameof(GS_AfterLevel.CleanupAfterExpedition))]
        [HarmonyPrefix]
        public static void CleanupPrefix()
        {
            LevelApi.InvokeEndLevelCallbacks();
        }
    }
}
