using CellMenu;
using GTFuckingXP.Extensions;
using System;
using UnityEngine;

namespace GTFuckingXP.Managers
{
    public class SelectLevelPathManager
    {
        private bool _isSetup;

        public bool IsVisible { get; private set; }

        public void Setup()
        {
            if (_isSetup)
            {
                return;
            }

            foreach (var playerBar in CM_PageLoadout.Current.m_playerLobbyBars)
            {
                var test = playerBar.m_clothesButton.gameObject.Instantiate<CM_LobbyScrollItem>("ClassButtonGameObject");
                test.transform.Translate(new Vector3(0f, -80f, 0f));
                test.gameObject.SetActive(true);

                // var p = (teste) => { LogManager.Debug("Reeeee"); };
                //test.SetOnBtnPressCallback(p);
            }
        }

        public void ShowLevelPaths(CM_PlayerLobbyBar lobbyBar)
        {
            lobbyBar.HidePopup();
            lobbyBar.m_popupVisible = true;

            lobbyBar.m_popupScrollWindow.m_infoBoxWidth = 700f;
            lobbyBar.m_popupScrollWindow.SetSize(new Vector2(1600f, 760f));
            lobbyBar.m_popupScrollWindow.ResetHeaders();
            Action<int> lvlPopupAction = _ => LvlPopup(lobbyBar);
            lobbyBar.m_popupScrollWindow.AddHeader("Levels",0, lvlPopupAction);

            lobbyBar.m_popupScrollWindow.SetPosition(new Vector2(0f, 350f));
            lobbyBar.m_popupScrollWindow.RespawnInfoBoxFromPrefab();

            Action<int> selectLevelAction = _ => SelectLevel();
            lobbyBar.m_popupScrollWindow.InfoBox.add_OnAcceptBtnPress(selectLevelAction);

            IsVisible = true;
            LvlPopup(lobbyBar);
            lobbyBar.ShowPopup();
        }

        public void HideLevelPaths(CM_PlayerLobbyBar lobbyBar)
        {

        }

        private void LvlPopup(CM_PlayerLobbyBar lobbyBar)
        {
        }

        private void SelectLevel()
        {

        }
    }
}
