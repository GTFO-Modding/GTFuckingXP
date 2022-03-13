using System;
using System.Collections.Generic;
using DevToolbelt.Information;
using EndskApi.Api;
using GTFuckingXP.Communication;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using Player;
using UnityEngine;

namespace GTFuckingXP.Scripts
{
    internal class DevTools : DevToolbelt.Menus.Base.BaseMenu
    {
        public DevTools(IntPtr intPtr) : base(intPtr)
        {
            enabled = false;

            _cheats.Add(new Cheat("Reload xp data", new InputCheat(KeyCode.F1, ": [F1]"), false, null));
            _cheats.Add(new Cheat("Change class", new InputCheat(KeyCode.F2, ": [F2]"), false, null));
            _cheats.Add(new Cheat("Level up", new InputCheat(KeyCode.F3, ": [F3]"), false, null));
            _cheats.Add(new Cheat("Level down", new InputCheat(KeyCode.F4, ": [F4]"), false, null));
        }

        public void ReloadData(Cheat _)
        {
            XpApi.ReloadData();
        }

        public void LevelUp(Cheat _)
        {
            if (XpApi.SetCurrentLevel(CacheApiWrapper.GetActiveLevel().LevelNumber + 1, out var cheatedXp))
            {
                CheatedXpMessage(cheatedXp);
            }
        }

        public void LevelDown(Cheat _)
        {
            if (XpApi.SetCurrentLevel(CacheApiWrapper.GetActiveLevel().LevelNumber - 1, out var cheatedXp))
            {
                CheatedXpMessage(cheatedXp);
            }
        }

        public void ChangeClass(Cheat _)
        {
            var levelLayouts = CacheApi.GetInstance<List<LevelLayout>>(CacheApiWrapper.XpModCacheName);
            var currentLayout = CacheApiWrapper.GetCurrentLevelLayout();

            var index = levelLayouts.IndexOf(currentLayout);
            if (levelLayouts.Count <= index + 1)
            {
                XpApi.ChangeCurrentLevelLayout(levelLayouts[0]);
            }
            else
            {
                XpApi.ChangeCurrentLevelLayout(levelLayouts[index + 1]);
            }
        }

        private void CheatedXpMessage(float xpAmount)
        {
            PlayerChatManager.WantToSentTextMessage(PlayerManager.GetLocalPlayerAgent(), $"Cheated {xpAmount}XP");
        }
    }
}
