using EndskApi.Api;
using EndskApi.Manager.Internal;
using HarmonyLib;

namespace EndskApi.Patches.Checkpoint
{
    [HarmonyPatch(typeof(CheckpointManager))]
    internal static class CheckpointManagerPatches
    {
        [HarmonyPatch(nameof(CheckpointManager.StoreCheckpoint))]
        [HarmonyPostfix]
        public static void StoreCheackpointPostfix()
        {
            CheckpointApi.InvokeCheckpointReachedCallbacks();
            NetworkManager.SendCheckpointReached();
        }

        [HarmonyPatch(nameof(CheckpointManager.OnLevelCleanup))]
        [HarmonyPostfix]
        public static void OnLevelCleanupPostfix()
        {
            CheckpointApi.InvokeCheckpointCleanupCallbacks();
            NetworkManager.SendCheckpointCleanups();
        }
    }
}
