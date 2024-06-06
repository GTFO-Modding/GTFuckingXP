using EndskApi.Api;
using EndskApi.Enums.EnemyKill;
using EndskApi.Information.EnemyKill;
using Enemies;
using HarmonyLib;
using Player;
using SNetwork;
using System.Collections.Generic;

namespace EndskApi.Patches.EnemyKill
{
    [HarmonyBefore(BepInExLoader.GUID, "com.dak.DamageNumbers")]
    [HarmonyPatch(typeof(Dam_EnemyDamageBase))]
    internal class EnemyDamageBasePatches
    {
        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveMeleeDamage))]
        [HarmonyPrefix]
        public static void MeleePrefix(Dam_EnemyDamageBase __instance, ref pFullDamageData data)
        {
            EnemyDamageBasePatchApi.InvokeReceiveMeleePrefix(__instance, ref data);
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveMeleeDamage))]
        [HarmonyPostfix]
        public static void MeleePostfix(Dam_EnemyDamageBase __instance, ref pFullDamageData data)
        {
            EnemyDamageBasePatchApi.InvokeReceiveMeleePostfix(__instance, ref data);
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveBulletDamage))]
        [HarmonyPrefix]
        public static void BulletPrefix(Dam_EnemyDamageBase __instance, ref pBulletDamageData data)
        {
            EnemyDamageBasePatchApi.InvokeReceiveBulletPrefix(__instance, ref data);
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveBulletDamage))]
        [HarmonyPostfix]
        public static void BulletPostfix(Dam_EnemyDamageBase __instance, ref pBulletDamageData data)
        {
            EnemyDamageBasePatchApi.InvokeReceiveBulletPostfix(__instance, ref data);
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveExplosionDamage))]
        [HarmonyPrefix]
        public static void ExplosionPrefix(Dam_EnemyDamageBase __instance, ref pExplosionDamageData data)
        {
            EnemyDamageBasePatchApi.InvokeReceiveExplosionPrefix(__instance, ref data);
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveExplosionDamage))]
        [HarmonyPostfix]
        public static void ExplosionPostfix(Dam_EnemyDamageBase __instance, ref pExplosionDamageData data)
        {
            EnemyDamageBasePatchApi.InvokeReceiveExplosionPostfix(__instance, ref data);
        }
    }
}
