using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace XpExpansions.Patches
{
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb))]
    public class DamEnemyDamageLimbPatches
    {
        public static bool MeleeDamagePrefix()
        {
            //TODO Look if the current class with level has the explosion ability, and explode the enemy instead of hitting it.

            return true;
        }
    }
}
