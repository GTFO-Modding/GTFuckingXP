using EndskApi.Manager;
using EndskApi.Patches.Init;
using Gear;
using HarmonyLib;
using System;
using System.Collections.Generic;

namespace EndskApi.Api
{
    public static class InitApi
    {
        private const string InitKey = "InitKey";

        static InitApi()
        {
            BepInExLoader.Harmony.PatchAll(typeof(PageRundownNewPatches));
            BepInExLoader.Harmony.PatchAll(typeof(GUIManagerPatches));
        }

        public static void AddInitCallback(Action callBack)
        {
            if (!CacheApi.TryGetInformation<List<Action>>(InitKey, out var callBackList, CacheApi.InternalCache, false))
            {
                callBackList = new List<Action>();
                CacheApi.SaveInformation(InitKey, callBackList, CacheApi.InternalCache);
            }

            callBackList.Add(callBack);
        }

        internal static void InvokeInitCallbacks()
        {
            if (CacheApi.TryGetInformation<List<Action>>(InitKey, out var callBackList, CacheApi.InternalCache, false))
            {
                foreach (var callBack in callBackList)
                {
                    try
                    {
                        callBack.Invoke();
                    }
                    catch (Exception ex)
                    {
                        LogManager.Error(ex.ToString());
                    }
                }

                CacheApi.RemoveInformation(InitKey, CacheApi.InternalCache);
            }
        }
    }
}
