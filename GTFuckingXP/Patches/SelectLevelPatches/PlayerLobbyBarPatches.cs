using CellMenu;
using HarmonyLib;

namespace GTFuckingXP.Patches.SelectLevelPatches
{
    [HarmonyPatch(typeof(CM_PlayerLobbyBar))]
    public class PlayerLobbyBarPatches
    {
        //private static List<CM_PlayerLobbyBar> _levelButtons = null;

        [HarmonyPatch(nameof(CM_PlayerLobbyBar.OnBtnPressAnywhere))]
        [HarmonyPrefix]
        public static void SetupFromPagePostfix(CM_PlayerLobbyBar __instance)
        {
            //if (!__instance.m_popupVisible)
            //{
            //    return;
            //}

            //if (InstanceCache.Instance.TryGetInstance<SelectLevelPathManager>(out var levelManager))
            //{
            //    if(levelManager.IsVisible)
            //    {
            //        levelManager.HideLevelPaths(__instance);
            //    }
            //}
        }

        //public static CM_PlayerLobbyBar CurrentLocalPlayerBar { get; private set; }

    }
}
