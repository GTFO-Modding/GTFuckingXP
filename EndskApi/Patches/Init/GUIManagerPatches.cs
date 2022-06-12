using EndskApi.Api;
using HarmonyLib;
using LevelGeneration;

namespace EndskApi.Patches.Init
{
    [HarmonyPatch(typeof(GuiManager))]
    internal class GUIManagerPatches
    {
        [HarmonyPatch(nameof(GuiManager.Setup))]
        [HarmonyPrefix]
        [HarmonyWrapSafe]
        public static void SetupPrefix()
        {
            InitApi.InvokeInitCallbacks();
        }
    }
}
