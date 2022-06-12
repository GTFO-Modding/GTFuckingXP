using EndskApi.Manager;
using EndskApi.Patches.EndLevel;
using EndskApi.Patches.StartLevel;
using System;
using System.Collections.Generic;

namespace EndskApi.Api
{
    public static class LevelApi
    {
        private const string EndLevelKey = "EndLevelKey";
        private const string StartLevelKey = "StartLevelKey";

        static LevelApi()
        {
            BepInExLoader.Harmony.PatchAll(typeof(GsAfterLevelPatches));
            BepInExLoader.Harmony.PatchAll(typeof(GsInLevelPatches));
        }

        public static void AddBeginLevelCallback(Action callBack)
        {
            if (!CacheApi.TryGetInformation<List<Action>>(StartLevelKey, out var callBackList, CacheApi.InternalCache, false))
            {
                callBackList = new List<Action>();
                CacheApi.SaveInformation(StartLevelKey, callBackList, CacheApi.InternalCache);
            }

            callBackList.Add(callBack);
        }

        public static void AddEndLevelCallback(Action callBack)
        {
            if (!CacheApi.TryGetInformation<List<Action>>(EndLevelKey, out var callBackList, CacheApi.InternalCache, false))
            {
                callBackList = new List<Action>();
                CacheApi.SaveInformation(EndLevelKey, callBackList, CacheApi.InternalCache);
            }

            callBackList.Add(callBack);
        }

        internal static void InvokeEndLevelCallbacks()
        {
            if (CacheApi.TryGetInformation<List<Action>>(EndLevelKey, out var callBackList, CacheApi.InternalCache, false))
            {
                foreach (var callBack in callBackList)
                {
                    try
                    {
                        callBack.Invoke();
                    }
                    catch (Exception ex)
                    {
                        LogManager.Error(ex);
                    }
                }
            }
        }

        internal static void InvokeStartLevelCallbacks()
        {
            if (CacheApi.TryGetInformation<List<Action>>(StartLevelKey, out var callBackList, CacheApi.InternalCache, false))
            {
                foreach (var callBack in callBackList)
                {
                    try
                    {
                        callBack.Invoke();
                    }
                    catch (Exception ex)
                    {
                        LogManager.Error(ex);
                    }
                }
            }
        }
    }
}
