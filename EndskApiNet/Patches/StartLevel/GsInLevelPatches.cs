using EndskApi.Api;
using HarmonyLib;

namespace EndskApi.Patches.StartLevel
{
    [HarmonyPatch(typeof(GS_InLevel))]
    internal class GsInLevelPatches
    {
        [HarmonyPatch(nameof(GS_InLevel.Enter))]
        [HarmonyPostfix]
        public static void EnterLevelPostfix()
        {
            LevelApi.InvokeStartLevelCallbacks();
        }
    }
}
