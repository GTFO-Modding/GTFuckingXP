using Gear;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace XpExpansions.Patches
{
    [HarmonyPatch(typeof(MeleeWeaponFirstPerson))]
    public class MeleeWeaponFirstPersonPatches
    {
        [HarmonyPatch(nameof(MeleeWeaponFirstPerson.DoAttackDamage)]
        [HarmonyPrefix]
        public void DoAttackDamagePostfix(MeleeWeaponFirstPerson __instance,
            MeleeWeaponDamageData data, bool isPush = false)
        {

        }
    }
}
