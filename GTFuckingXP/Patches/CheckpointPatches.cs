using EndskApi.Api;
using GTFuckingXP.Extensions;
using GTFuckingXP.Managers;
using GTFuckingXP.Scripts;
using HarmonyLib;

namespace GTFuckingXP.Patches
{
    [HarmonyPatch(typeof(CheckpointManager))]
    public class CheckpointPatches
    {
        //This patch is only getting called on the Hosts computer.
        [HarmonyPatch(nameof(CheckpointManager.StoreCheckpoint))]
        [HarmonyPostfix]
        private static void StoreCheckpointPostfix()
        {
            LogManager.Debug("Saving Checkpoint");
            CreateCheckpointData();
            NetworkApiXpManager.SendCheckpointReached();
        }

        //This patch is only getting called on the Hosts computer.
        [HarmonyPatch(nameof(CheckpointManager.OnLevelCleanup))]
        [HarmonyPostfix]
        private static void ReloadCheckpointPostfix()
        {
            CheckpointsCleanup();
            NetworkApiXpManager.SendCheckpointCleanups();
        }

        public static void CreateCheckpointData()
        {
            if (CacheApi.TryGetInstance(out XpHandler xpHandler))
            {
                CacheApiWrapper.SetXpStorageData(xpHandler.CurrentTotalXp);
            }
            else
            {
                LogManager.Error("No XpHandler was found, while trying to store the Checkpoint!");
            }
        }

        public static void CheckpointsCleanup()
        {
            CacheApi.RemoveInformation(CacheApiWrapper.CheckpointData);
        }
    }
}
