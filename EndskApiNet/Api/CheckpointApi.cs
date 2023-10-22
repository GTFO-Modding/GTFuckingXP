using EndskApi.Manager.Internal;
using EndskApi.Patches.Checkpoint;
using System;
using System.Collections.Generic;

namespace EndskApi.Api
{
    public static class CheckpointApi
    {
        private const string CheckpointReachedKey = "CheckpointReachedKey";
        private const string CleanupCheckpointKey = "CheckpointCleanupKey";

        static CheckpointApi()
        {
            BepInExLoader.Harmony.PatchAll(typeof(CheckpointManagerPatches));
            NetworkManager.Setup();
        }

        /// <summary>
        /// Adds <paramref name="callBack"/> to be called whenever a checkpoint has been reached.
        /// </summary>
        /// <param name="callBack">The callback that should be invoked whenever a checkpoint got reached.</param>
        public static void AddCheckpointReachedCallback(Action callBack)
        {
            if(!CacheApi.TryGetInformation<List<Action>>(CheckpointReachedKey,out var callBackList, CacheApi.InternalCache, false))
            {
                callBackList = new List<Action>();
                CacheApi.SaveInformation(CheckpointReachedKey, callBackList, CacheApi.InternalCache);
            }

            callBackList.Add(callBack);
        }

        /// <summary>
        /// Adds <paramref name="callBack"/> to be called whenever the checkpoint data should be cleaned up.
        /// </summary>
        /// <param name="callBack">The callback that should be invoked whenever the checkpoint data should be cleaned up.</param>
        public static void AddCheckpointCleanupCallback(Action callBack)
        {
            if (!CacheApi.TryGetInformation<List<Action>>(CleanupCheckpointKey, out var callBackList, CacheApi.InternalCache, false))
            {
                callBackList = new List<Action>();
                CacheApi.SaveInformation(CleanupCheckpointKey, callBackList, CacheApi.InternalCache);
            }

            callBackList.Add(callBack);
        }

        /// <summary>
        /// Removes <paramref name="callBack"/> from the list that gets called on checkpoint reached.
        /// </summary>
        public static void RemoveCheckpointReachedCallback(Action callBack)
        {
            if (CacheApi.TryGetInformation<List<Action>>(CheckpointReachedKey, out var callBackList, CacheApi.InternalCache, false))
            {
               callBackList.Remove(callBack);
            }
        }

        /// <summary>
        /// Removes <paramref name="callBack"/> from the list that gets called on checkpoint cleanup
        /// </summary>
        public static void RemoveCheckpointCleanupCallback(Action callBack)
        {
            if (CacheApi.TryGetInformation<List<Action>>(CleanupCheckpointKey, out var callBackList, CacheApi.InternalCache, false))
            {
                callBackList.Remove(callBack);
            }
        }

        internal static void InvokeCheckpointReachedCallbacks()
        {
            if (CacheApi.TryGetInformation<List<Action>>(CheckpointReachedKey, out var callBackList, CacheApi.InternalCache, false))
            {
                foreach(var callBack in callBackList)
                {
                    callBack.Invoke();
                }
            }
        }

        internal static void InvokeCheckpointCleanupCallbacks()
        {
            if (CacheApi.TryGetInformation<List<Action>>(CleanupCheckpointKey, out var callBackList, CacheApi.InternalCache, false))
            {
                foreach (var callBack in callBackList)
                {
                    callBack.Invoke();
                }
            }
        }
    }
}
