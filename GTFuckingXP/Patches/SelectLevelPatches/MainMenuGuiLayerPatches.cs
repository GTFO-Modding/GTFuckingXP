using CellMenu;
using EndskApi.Api;
using GTFuckingXP.Extensions;
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
            if (pageEnum == eCM_MenuPage.CMP_LOADOUT && (byte)GameStateManager.CurrentStateName < 9)
            {
                CacheApiWrapper.CreateRegisterAndReturnComponent<SelectLevelPathHandler>();

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
                if (CacheApi.TryGetInstance<SelectLevelPathHandler>(out var instance, CacheApiWrapper.XpModCacheName))
                {
                    instance.gameObject.SetActive(false);
                }
            }

            LogManager.Debug($"ShowPagePostfix {(__instance.m_pages[(int)pageEnum] is null ? "Null" : "NotNull")}, page is {pageEnum.ToString()}");
        }
    }
}
