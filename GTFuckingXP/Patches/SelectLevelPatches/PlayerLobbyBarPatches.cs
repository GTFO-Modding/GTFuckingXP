using CellMenu;
using HarmonyLib;
using GTFuckingXP.Extensions;
using GTFuckingXP.Managers;
using System;
using System.Collections.Generic;
using GTFuckingXP.Information.Level;
using Localization;

namespace GTFuckingXP.Patches.SelectLevelPatches
{
    [HarmonyPatch(typeof(CM_PlayerLobbyBar))]
    public class PlayerLobbyBarPatches
    {
        private static InstanceCache _instanceCache;

        internal static InstanceCache InstanceCache
        {
            get
            {
                if (_instanceCache == null)
                {
                    _instanceCache = InstanceCache.Instance;
                }
                return _instanceCache;
            }
        }

        /// <summary>
        /// When any button got pressed, set the classbutton dimmed.
        /// </summary>
        [HarmonyPatch(nameof(CM_PlayerLobbyBar.Select))]
        [HarmonyPostfix]
        public static void SelectPostfix(CM_PlayerLobbyBar __instance)
        {
            LogManager.Debug("Select Postfix");
            if (InstanceCache.Instance.TryGetInformation<CM_LobbyScrollItem>(__instance.GetInstanceID(), out var classButton))
            {
                classButton.IsSelected = false;
                classButton.IsDimmed = true;
            }
        }

        /// <summary>
        /// When the selection window gets unfocused, set the classbutton visible again.
        /// </summary>
        [HarmonyPatch(nameof(CM_PlayerLobbyBar.UnSelect))]
        [HarmonyPostfix]
        public static void UnSelectPostfix(CM_PlayerLobbyBar __instance)
        {
            LogManager.Debug("Unselect Postfix");
            if (InstanceCache.TryGetInformation<CM_LobbyScrollItem>(__instance.GetInstanceID(), out var classButton))
            {
                classButton.IsSelected = false;
                classButton.IsDimmed = false;
            }
        }

        [HarmonyPatch(nameof(CM_PlayerLobbyBar.SetupFromPage))]
        [HarmonyPostfix]
        public static void SetupFromPagePostfix(CM_PlayerLobbyBar __instance)
        {
            LogManager.Debug($"SetupFromPage Postfix on {__instance.GetInstanceID()}");
            var classButton = __instance.m_clothesButton.gameObject.Instantiate<CM_LobbyScrollItem>("ClassSelectorButton");

            classButton.SetText("TODO");

            InstanceCache.SetInformation(__instance.GetInstanceID(), classButton);

            classButton.transform.Translate(new UnityEngine.Vector3(0f, -70f, 0f));
            classButton.SetOnBtnPressCallback((Action<int>)((int test) =>
            {
                LogManager.Debug($"Button pressed with {test} as parameter");
                __instance.Select();
                classButton.IsSelected = true;
                ShowClassesSelector(__instance);
            }));
        }

        [HarmonyPatch(nameof(CM_PlayerLobbyBar.HideLoadoutUI))]
        [HarmonyPostfix]
        public static void HideLoadoutUiPostfix(CM_PlayerLobbyBar __instance, bool hide)
        {
            //LogManager.Debug($"HideLoadoutUi Postfix on {__instance.GetInstanceID()}");
            if (!__instance.m_introDone)
            {
                return;
            }

            if (__instance.m_player is null)
            {
                return;
            }

            //LogManager.Debug($"Intro done and player not null {(__instance.m_player.IsLocal ? "Player local" : "Player not Local")}");
            var scrollItem = InstanceCache.Instance.GetInformation<CM_LobbyScrollItem>(__instance.GetInstanceID());
            if (__instance.m_player.IsLocal)
            {
                scrollItem.gameObject.SetActive(!hide);
                //LogManager.Debug($"Set scrollItem.Visible =  {!hide}");
            }

            if (!__instance.m_player.IsBot)
            {
                return;
            }

            scrollItem.gameObject.SetActive(false);
        }

        private static void ShowClassesSelector(CM_PlayerLobbyBar lobbyBar)
        {
            LogManager.Debug("Calling ShowClass Selector method.");

            lobbyBar.HidePopup();
            lobbyBar.m_popupVisible = true;

            lobbyBar.m_popupScrollWindow.m_infoBoxWidth = 700f;
            lobbyBar.m_popupScrollWindow.SetSize(new UnityEngine.Vector2(1600f, 700f));
            lobbyBar.m_popupScrollWindow.ResetHeaders();

            var levelLayouts = InstanceCache.GetInstance<List<LevelLayout>>();
            var headerNames = new List<string>();

            foreach(var layout in levelLayouts)
            {
                if(!headerNames.Contains(layout.GroupName))
                {
                    headerNames.Add(layout.GroupName);
                }
            }
            InstanceCache.SetInstance(headerNames);

            for(int i = 0; i < headerNames.Count; i++)
            {
                lobbyBar.m_popupScrollWindow.AddHeader(headerNames[i], i, 
                    (Action<int>)((int headerIndex) => 
                    {
                        LogManager.Debug($"Header select call. HeaderIndex was {headerIndex}");
                        ChangeClassHeader(headerNames[i], i, lobbyBar); 
                    }));
            }

            lobbyBar.m_popupScrollWindow.RespawnInfoBoxFromPrefab(lobbyBar.m_popupInfoBoxWeaponPrefab);
            lobbyBar.m_popupScrollWindow.InfoBox.add_OnAcceptBtnPress((Action<int>)((int i) => { LogManager.Debug($"OnAcceptPress {i}"); }));
            lobbyBar.m_popupScrollWindow.InfoBox.add_OnRejectBtnPress((Action<int>)((int i) => { LogManager.Debug($"RejectPress {i}"); }));

            ChangeClassHeader(headerNames[0], 0, lobbyBar);

            lobbyBar.ShowPopup();
        }

        private static void ChangeClassHeader(string groupName, int key, CM_PlayerLobbyBar lobbyBar)
        {
            LogManager.Debug($"Showing groupname {groupName}");

            var contentItems = new Il2CppSystem.Collections.Generic.List<iScrollWindowContent>();
            var levelLayouts = InstanceCache.GetInstance<List<LevelLayout>>();
            var activeLayout = InstanceCache.GetCurrentLevelLayout();

            var infoBox = lobbyBar.m_popupScrollWindow.InfoBox;

            CM_LobbyScrollItem selected = null;

            foreach (var layout in levelLayouts)
            {
                if(layout.GroupName == groupName)
                {
                    var content = GOUtil.SpawnChildAndGetComp<CM_LobbyScrollItem>(lobbyBar.m_clothesCardPrefab, lobbyBar.transform);
                    content.TextMeshRoot = lobbyBar.m_parentPage.transform;
                    content.SetupFromLobby(lobbyBar.transform, lobbyBar, true);
                    content.ForcePopupLayer();
                    content.m_descText.text = "";
                    content.m_subTitleText.text = "";
                    
                    if(layout.PersistentId == activeLayout.PersistentId)
                    {
                        content.m_subTitleText.text = "<color=orange>" + Text.Get(492U) + "</color>";
                        content.IsSelected = true;
                        selected = content;
                    }

                    content.m_nameText.text = layout.Header;
                    content.add_OnBtnPressCallback((Action<int>)((int par) =>
                    {
                        LogManager.Debug($"LayoutName {layout.Header} and Id is {layout.PersistentId}");

                        if(selected != null)
                            selected.IsSelected = false;
                        content.IsSelected = true;
                        selected = content;

                        CoroutineManager.BlinkIn(content.gameObject);
                        //InstanceCache.SetCurrentLevelLayout(layout);

                        if(layout.PersistentId != InstanceCache.Instance.GetCurrentLevelLayout().PersistentId)
                        {
                            infoBox.SetInfoBox("Wah", "SubTitle", "Description", "Use", "Deutschland", null);
                        }
                        else
                        {
                            infoBox.SetInfoBox("Wah2", "SubTitle2", "Description2", "Use2", "Deutschland2", null);
                        }
                    }));

                    content.m_alphaSpriteOnHover = true;
                    content.m_alphaTextOnHover = true;

                    contentItems.Add(content.Cast<iScrollWindowContent>());
                }
            }

            lobbyBar.m_popupScrollWindow.SetContentItems(contentItems);

            foreach(var content in contentItems)
            {
                content.Cast<CM_LobbyScrollItem>().UpdateSizesAndOffsets();
            }

            lobbyBar.ShowPopup();
            lobbyBar.m_popupScrollWindow.SelectHeader(key);
        }

        private void SelectItem(LevelLayout selectedLevelLayout)
        {

        }
    }
}
