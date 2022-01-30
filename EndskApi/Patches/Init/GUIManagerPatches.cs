using EndskApi.Api;
using HarmonyLib;

namespace EndskApi.Patches.Init
{
    [HarmonyPatch(typeof(GuiManager))]
    internal class GUIManagerPatches
    {
        [HarmonyPatch(nameof(GuiManager.Setup))]
        [HarmonyPrefix]
        public static void SetupPrefix()
        {
            InitApi.InvokeInitCallbacks();
        }
    }
}
