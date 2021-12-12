using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Managers;
using GTFuckingXP.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTFuckingXP.Communication
{
    public static class XpApi
    {
        public static bool AddXp(uint xpAmount)
        {
            if (InstanceCache.Instance.TryGetInstance<XpHandler>(out var xpHandler))
            {
                xpHandler.AddXp(new EnemyXp(0,"", xpAmount, xpAmount, 0), default, false, false);
                xpHandler.CheckForLevelThresholdReached(default, false);

                return true;
            }

            return false;
        }

        public static bool SetCurrentTotalXp(uint newTotalXpAmount)
        {
            if(InstanceCache.Instance.TryGetInstance<XpHandler>(out var xpHandler))
            {
                xpHandler.CurrentTotalXp = newTotalXpAmount;
                xpHandler.CheckForLevelThresholdReached(default, false);

                return true;
            }

            return false;
        }

        public static bool SetCurrentLevel(int levelNumber)
        {
            var instanceCache = InstanceCache.Instance;

            var levelLayout = instanceCache.GetCurrentLevelLayout().Levels;
            return SetCurrentTotalXp(levelLayout.First(it => it.LevelNumber == levelNumber).TotalXpRequired + 1);
        }
    }
}
