using CellMenu;
using HarmonyLib;
using GTFuckingXP.Extensions;
using GTFuckingXP.Managers;
using System;
using System.Collections.Generic;
using GTFuckingXP.Information.Level;
using Localization;
using GTFuckingXP.Information.ClassSelector;
using System.Linq;

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

        ///// <summary>
        ///// When any button got pressed, set the classbutton dimmed.
        ///// </summary>
        //[HarmonyPatch(nameof(CM_PlayerLobbyBar.Select))]
        //[HarmonyPostfix]
        //public static void SelectPostfix(CM_PlayerLobbyBar __instance)
        //{
        //    LogManager.Debug("Select Postfix");
        //    if (InstanceCache.Instance.TryGetInformation<CM_LobbyScrollItem>(__instance.GetInstanceID(), out var classButton))
        //    {
        //        //classButton.IsSelected = false;
        //        //classButton.IsDimmed = true;
        //    }
        //}

        ///// <summary>
        ///// When the selection window gets unfocused, set the classbutton visible again.
        ///// </summary>
        //[HarmonyPatch(nameof(CM_PlayerLobbyBar.UnSelect))]
        //[HarmonyPostfix]
        //public static void UnSelectPostfix(CM_PlayerLobbyBar __instance)
        //{
        //    LogManager.Debug("Unselect Postfix");
        //    if (InstanceCache.TryGetInformation<CM_LobbyScrollItem>(__instance.GetInstanceID(), out var classButton))
        //    {
        //        //classButton.IsSelected = false;
        //        //classButton.IsDimmed = false;
        //    }
        //}

        [HarmonyPatch(nameof(CM_PlayerLobbyBar.SetupFromPage))]
        [HarmonyPostfix]
        public static void SetupFromPagePostfix(CM_PlayerLobbyBar __instance)
        {
            LogManager.Debug($"SetupFromPage Postfix on {__instance.GetInstanceID()}");
            var classButton = __instance.m_clothesButton.gameObject.Instantiate<CM_LobbyScrollItem>("ClassSelectorButton");

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
            if (!__instance.m_introDone)
            {
                return;
            }

            if (__instance.m_player is null)
            {
                return;
            }

            var scrollItem = InstanceCache.Instance.GetInformation<CM_LobbyScrollItem>(__instance.GetInstanceID());
            if (__instance.m_player.IsLocal)
            {
                scrollItem.gameObject.SetActive(!hide);
                foreach (var text in scrollItem.GetTexts())
                {
                    text.text = "Class selector";
                    text.ForceMeshUpdate();
                }
            }

            if (!__instance.m_player.IsBot)
            {
                return;
            }
        }

        private static void ShowClassesSelector(CM_PlayerLobbyBar lobbyBar)
        {
            LogManager.Debug("Calling ShowClass Selector method.");

            lobbyBar.HidePopup();
            lobbyBar.m_popupVisible = true;

            lobbyBar.m_popupScrollWindow.m_infoBoxWidth = 700f;
            lobbyBar.m_popupScrollWindow.SetSize(new UnityEngine.Vector2(1600f, 700f));
            lobbyBar.m_popupScrollWindow.ResetHeaders();

            var groups = InstanceCache.GetInstance<List<Group>>();

            AddHeaders(lobbyBar, groups);

            lobbyBar.m_popupScrollWindow.SetPosition(new UnityEngine.Vector2(0f, 350f));
            //lobbyBar.m_popupScrollWindow.RespawnInfoBoxFromPrefab(lobbyBar.m_popupInfoBoxBoosterImplantPrefab);
            lobbyBar.m_popupScrollWindow.RespawnInfoBoxFromPrefab(lobbyBar.m_popupInfoBoxWeaponPrefab);
            //lobbyBar.m_popupScrollWindow.InfoBox.add_OnAcceptBtnPress((Action<int>)((int i) => { LogManager.Debug($"OnAcceptPress {i}"); }));
            //lobbyBar.m_popupScrollWindow.InfoBox.add_OnRejectBtnPress((Action<int>)((int i) => { LogManager.Debug($"RejectPress {i}"); }));

            ChangeClassHeader(groups[0].Name, 0, lobbyBar);

            lobbyBar.ShowPopup();

            var infoBox = lobbyBar.m_popupScrollWindow.InfoBox;
            float anchorDifference;
            if (!InstanceCache.TryGetAnchorDifference(out anchorDifference))
            {
                anchorDifference = (infoBox.m_infoMainTitleText.rectTransform.anchoredPosition.y * -1) - 40f;
                InstanceCache.SetAnchorDifference(anchorDifference);
            }

            infoBox.m_infoMainTitleText.rectTransform.anchoredPosition = new UnityEngine.Vector2(0f, infoBox.m_infoMainTitleText.rectTransform.anchoredPosition.y + anchorDifference);
            infoBox.m_infoDescriptionText.rectTransform.anchoredPosition = new UnityEngine.Vector2(0f, infoBox.m_infoDescriptionText.rectTransform.anchoredPosition.y + anchorDifference);

            infoBox.m_infoDescriptionText.fontSizeMin = infoBox.m_infoDescriptionText.fontSizeMax;
        }

        private static void ChangeClassHeader(string groupName, int key, CM_PlayerLobbyBar lobbyBar)
        {
            LogManager.Debug($"Showing groupname {groupName}");

            var contentItems = new Il2CppSystem.Collections.Generic.List<iScrollWindowContent>();
            var levelLayouts = InstanceCache.GetInstance<List<LevelLayout>>();
            var activeLayout = InstanceCache.GetCurrentLevelLayout();

            var infoBox = lobbyBar.m_popupScrollWindow.InfoBox;
            var unusedIconSpaceY = infoBox.m_infoMainIcon.size.y;
            infoBox.m_infoMainIcon.gameObject.SetActive(false);
            infoBox.m_infoMainIcon.enabled = false;

            //infoBox.m_infoMainTitleText.transform.Translate(new UnityEngine.Vector3(0f, unusedIconSpaceY, 0f));
            //infoBox.m_infoDescriptionText.transform.Translate(new UnityEngine.Vector3(0f, unusedIconSpaceY, 0f));

            CM_LobbyScrollItem selected = null;

            foreach (var layout in levelLayouts)
            {
                if(layout.GroupPersistentId == key)
                {
                    var content = GOUtil.SpawnChildAndGetComp<CM_LobbyScrollItem>(lobbyBar.m_clothesCardPrefab, lobbyBar.transform);
                    content.TextMeshRoot = lobbyBar.m_parentPage.transform;
                    content.SetupFromLobby(lobbyBar.transform, lobbyBar, true);
                    content.ForcePopupLayer();
                    content.m_descText.text = "";
                    content.m_subTitleText.text = "";
                    
                    if(layout.PersistentId == activeLayout.PersistentId)
                    {
                        selected = content;
                        selected.IsSelected = true;
                        SelectItem(content, selected);
                    }

                    content.m_nameText.text = layout.Header;
                    content.add_OnBtnPressCallback((Action<int>)((int par) =>
                    {
                        LogManager.Debug($"LayoutName {layout.Header} and Id is {layout.PersistentId}");

                        if(selected != null)
                            selected.IsSelected = false;
                        content.IsSelected = true;
                        SelectItem(content, selected);
                        selected = content;

                        CoroutineManager.BlinkIn(content.gameObject);

                        infoBox.SetInfoBox(layout.Header, "", layout.InfoText, "", "", new UnityEngine.Sprite());
                        InstanceCache.SetCurrentLevelLayout(layout);
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

            var test = infoBox.transform.FindChild("InfoBox/IconBackground");
            LogManager.Debug($"Child is null {test is null}");
            test.gameObject.SetActive(false);
        }

        private static void SelectItem(CM_LobbyScrollItem newSelectItem, CM_LobbyScrollItem oldSelectItem)
        {
            if(oldSelectItem != null)
            {
                oldSelectItem.m_subTitleText.text = "";
                InstanceCache.SetInstance<CM_LobbyScrollItem>(null);
            }

            if(newSelectItem != null)
            {
                newSelectItem.m_subTitleText.text = "<color=orange>" + Text.Get(492U) + "</color>";
                InstanceCache.SetInstance(newSelectItem);
            }
        }

        private static void AddHeaders(CM_PlayerLobbyBar lobbyBar, List<Group> groups)
        {
            var group0 = groups.FirstOrDefault(it => it.PersistentId == 0);
            var group1 = groups.FirstOrDefault(it => it.PersistentId == 1);
            var group2 = groups.FirstOrDefault(it => it.PersistentId == 2);
            var group3 = groups.FirstOrDefault(it => it.PersistentId == 3);

            //I can't do that in a loop for some reason, so i decided to go some hardcoded way :(.
            if (group0 != null)
            {
                lobbyBar.m_popupScrollWindow.AddHeader(group0.Name, 0,
                    (Action<int>)((int headerIndex) =>
                    {
                        LogManager.Debug($"Header select call. HeaderIndex was {headerIndex}, or 0");
                        ChangeClassHeader(group0.Name, 0, lobbyBar);
                    }));
            }

            if (group1 != null)
            {
                lobbyBar.m_popupScrollWindow.AddHeader(group1.Name, 1,
                    (Action<int>)((int headerIndex) =>
                    {
                        LogManager.Debug($"Header select call. HeaderIndex was {headerIndex}, or 1");
                        ChangeClassHeader(group1.Name, 1, lobbyBar);
                    }));
            }

            if (group2 != null)
            {
                lobbyBar.m_popupScrollWindow.AddHeader(group2.Name, 2,
                    (Action<int>)((int headerIndex) =>
                    {
                        LogManager.Debug($"Header select call. HeaderIndex was {headerIndex}, or 2");
                        ChangeClassHeader(group2.Name, 2, lobbyBar);
                    }));
            }

            if (group3 != null)
            {
                lobbyBar.m_popupScrollWindow.AddHeader(group3.Name, 3,
                    (Action<int>)((int headerIndex) =>
                    {
                        LogManager.Debug($"Header select call. HeaderIndex was {headerIndex}, or 3");
                        ChangeClassHeader(group3.Name, 3, lobbyBar);
                    }));
            }
        }
    }
}
