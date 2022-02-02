using CellMenu;
using CustomBoostersXp.Extensions;
using CustomBoostersXp.Information.BoosterInfo;
using EndskApi.Api;
using GTFuckingXP.Extensions;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;

namespace CustomBoostersXp.Patches
{
    [HarmonyPatch(typeof(CM_PlayerLobbyBar))]
    public class CmPlayerLobbyBarPatches 
    {
        [HarmonyPatch(nameof(CM_PlayerLobbyBar.UpdateBoosterSelectionPoup))]
        [HarmonyPrefix]
        public static bool UpdateBoosterSelectionPoupPrefix(CM_PlayerLobbyBar __instance,
             BoosterImplantCategory category, int selectedBoosterInstanceID)
        {
            List<iScrollWindowContent> contentItems = new List<iScrollWindowContent>();
            
            var implantInventory = PersistentInventoryManager.GetBoosterImplantInventory(category);

            var activeClass = CacheApiWrapper.GetCurrentLevelLayout();
            var boosters = CacheApi.GetInstance<List<Booster>>(CacheApiWrapper.XpModCacheName).Where(it => it.Category == category && it.UsableForClassPersistentIds.Contains(activeClass.PersistentId));
            CacheApiWrapperBooster.TryGetBooster(category, out var booster);


            //for (int index = 0; index < BoosterImplantConstants.InventoryLimitPerCategory[(int)category]; ++index)
            //{
            //    CM_BoosterImplantSlotItem comp = GOUtil.SpawnChildAndGetComp<CM_BoosterImplantSlotItem>(this.m_boosterImplantCardPrefab, this.transform);
            //    comp.TextMeshRoot = this.m_parentPage.transform;
            //    comp.SetupFromLobby(this.transform, this, true);
            //    comp.ForcePopupLayer();
            //    if (index >= 0)
            //    {
            //        if (index < implantInventory.Count)
            //        {
            //            comp.LoadData(implantInventory[index]);
            //            if (implantInventory[index].Prepared || (long)implantInventory[index].InstanceId == (long)selectedBoosterInstanceID)
            //                this.SelectBoosterImplant(comp);
            //        }
            //        else
            //            comp.SetupAsEmptySlot();
            //        comp.PlayIntro((float)index * 0.1f);
            //    }
            //    comp.m_alphaSpriteOnHover = true;
            //    comp.m_alphaTextOnHover = true;
            //    contentItems.Add((iScrollWindowContent)comp);
            //}
            //this.m_popupScrollWindow.SetContentItems(contentItems);
            //for (int index = 0; index < contentItems.Count; ++index)
            //    ((CM_LobbyScrollItem)contentItems[index]).UpdateSizesAndOffsets();
            //this.RefreshBoosterImplantInfo();
            //this.ShowPopup();
            //this.m_popupScrollWindow.SelectHeader((int)category);

            return false;
        }
    }
}
