using System;
using System.Collections.Generic;
using EndskApi.Api;
using EndskApi.Scripts;
using GTFuckingXP.Communication;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using Player;
using EndskApi.Information.Menus;
using EndskApi.Manager;

namespace GTFuckingXP.Scripts
{
    internal class DevTools : BaseMenu
    {
        public DevTools(IntPtr intPtr) : base(intPtr)
        {
            enabled = false;

            _tools.Add(new Tool("Reload xp data", MenuInputProvider.F1, false, null));
            _tools.Add(new Tool("Change class", MenuInputProvider.F2, false, null));
            _tools.Add(new Tool("Level up", MenuInputProvider.F3, false, null));
            _tools.Add(new Tool("Level down", MenuInputProvider.F4, false, null));
        }

        public void ReloadData(Tool _)
        {
            XpApi.ReloadData();
        }

        public void LevelUp(Tool _)
        {
            if (XpApi.SetCurrentLevel(CacheApiWrapper.GetActiveLevel().LevelNumber + 1, out var cheatedXp))
            {
                CheatedXpMessage(cheatedXp);
            }
        }

        public void LevelDown(Tool _)
        {
            if (XpApi.SetCurrentLevel(CacheApiWrapper.GetActiveLevel().LevelNumber - 1, out var cheatedXp))
            {
                CheatedXpMessage(cheatedXp);
            }
        }

        public void ChangeClass(Tool _)
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
