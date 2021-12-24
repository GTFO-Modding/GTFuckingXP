using HarmonyLib;

namespace GTFuckingXP.Patches.MtfoPatches
{
    public class HotRealoaderPatch
    {
        /// Gets patches dynamically if mtfo exists in the MtfoUtils class
        [HarmonyWrapSafe]
        [HarmonyPostfix]
        public static void HotRealoadPostfix()
        {

        }
    }
}
