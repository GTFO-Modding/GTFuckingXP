using CellMenu;
using CustomBoostersXp.Information.BoosterInfo;
using GTFuckingXP.Managers;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBoostersXp.Patches
{
    [HarmonyPatch(typeof(CM_PlayerLobbyBar))]
    public class CmPlayerLobbyBarPatches 
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

        [HarmonyPatch(nameof(CM_PlayerLobbyBar.UpdateBoosterSelectionPoup)]
        public static bool UpdateBoosterSelectionPoupPrefix(CM_PlayerLobbyBar __instance)
        {
            var boosters = InstanceCache.GetInstance<List<Booster>>();

            return false;
        }
    }
}
