using EndskApi.Patches.EndLevel;
using System;
using System.Collections.Generic;

namespace EndskApi.Api
{
    public static class EndLevelApi
    {
        private const string EndLevelKey = "EndLevelKey";

        static EndLevelApi()
        {
            BepInExLoader.Harmony.PatchAll(typeof(GsAfterLevelPatches));
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
                    callBack.Invoke();
                }
            }
        }
    }
}
