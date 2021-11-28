using Gear;
using GTFuckingXP.Extensions;
using GTFuckingXP.Managers;
using HarmonyLib;
using static Weapon;

namespace GTFuckingXP.Patches
{
    //[HarmonyPatch(typeof(BulletWeapon))]
    //public class BulletWeaponPatches
    //{
    //    [HarmonyPatch(nameof(BulletWeapon.BulletHit))]
    //    [HarmonyPrefix]
    //    public static void Prefix(ref WeaponHitData weaponRayData)
    //    {
    //        LogManager.Debug($"Weapon hit from {weaponRayData.owner.name}.");

    //        var currentLevel = InstanceCache.Instance.GetActiveLevel();
    //        weaponRayData.damage = weaponRayData.damage * currentLevel.WeaponDamageMultiplier;
    //    }
    //}
}
