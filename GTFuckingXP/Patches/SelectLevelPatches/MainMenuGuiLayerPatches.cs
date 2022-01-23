using CellMenu;
using GTFuckingXP.Managers;
using GTFuckingXP.Scripts.SelectLevelPath;
using HarmonyLib;

namespace GTFuckingXP.Patches.SelectLevelPatches
{
    [HarmonyPatch(typeof(MainMenuGuiLayer))]
    public class MainMenuGuiLayerPatches
    {
        [HarmonyPatch(nameof(MainMenuGuiLayer.ChangePage))]
        [HarmonyPostfix]
        public static void ShowPagePostfix(MainMenuGuiLayer __instance, eCM_MenuPage pageEnum)
        {
            var instanceCache = InstanceCache.Instance;

            if (pageEnum == eCM_MenuPage.CMP_LOADOUT && (byte)GameStateManager.CurrentStateName < 9)
            {
                instanceCache.CreateRegisterAndReturnComponent<SelectLevelPathHandler>();

                //foreach (var item in __instance.PageLoadout.m_playerLobbyBars)
                //{
                //    if (instanceCache.TryGetInformation(item.GetInstanceID(), out CM_LobbyScrollItem button))
                //    {
                //        foreach(var text in button.GetTexts())
                //        {
                //            text.SetText("Class Selector");
                //        }
                //    }
                //}
            }
            else
            {
                if (instanceCache.TryGetInstance<SelectLevelPathHandler>(out var instance, false))
                {
                    instance.gameObject.SetActive(false);
                }
            }

            LogManager.Debug($"ShowPagePostfix {(__instance.m_pages[(int)pageEnum] is null ? "Null" : "NotNull")}, page is {pageEnum.ToString()}");
        }
    }
}
