using Gear;
using HarmonyLib;
using static Weapon;

namespace GTFuckingXp.Patches
{
    [HarmonyPatch(typeof(BulletWeapon))]
    internal static class SentryGunCheckPatches
    {
        internal static bool SentryShot { get; private set; } = false;

        [HarmonyPatch(nameof(BulletWeapon.BulletHit))]
        [HarmonyBefore("Dinorush.ExtraWeaponCustomization")] // EWC might modify allowDirectionalBonus
        [HarmonyPrefix]
        private static void Prefix_BulletHit(ref WeaponHitData weaponRayData, bool allowDirectionalBonus)
        {
            // Auto sentry has back damage, shotgun sentry has vfxBulletHit unset, normal guns won't hit either condition
            if (!allowDirectionalBonus || weaponRayData.vfxBulletHit != null)
                SentryShot = true;
        }

        [HarmonyPatch(nameof(BulletWeapon.BulletHit))]
        [HarmonyPostfix]
        private static void Postfix_BulletHit()
        {
            SentryShot = false;
        }
    }
}
