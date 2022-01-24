using CustomBoostersXp.Information.BoosterInfo;
using GTFuckingXP.Managers;
using System.Collections.Generic;

namespace CustomBoostersXp.Extensions
{
    public static class BoosterInstanceCacheExtensions
    {
        private const string BoldBoosterKey = "BoldBoosterKey";
        private const string MutedBoosterKey = "MutedBoosterKey";
        private const string AggressiveBoosterKey = "AggressiveBoosterKey";

        private const string HiddenBoosterKey = "HiddenBooster";

        private static int _boosterIdCount = 0;

        internal static int SetBooster(this InstanceCache instanceCache, Booster booster)
        {
            switch(booster.Category)
            {
                case BoosterImplantCategory.Bold:
                    instanceCache.SetBoldBooster(booster);
                    return -1;
                case BoosterImplantCategory.Muted:
                    instanceCache.SetMutedBooster(booster);
                    return -1;
                case BoosterImplantCategory.Aggressive:
                    instanceCache.SetAggressiveBooster(booster);
                    return -1;
            }

            return instanceCache.AddHiddenBooster(booster);
        }

        internal static bool TryGetBooster(this InstanceCache instanceCache, BoosterImplantCategory category, out Booster booster)
        {
            switch (category)
            {
                case BoosterImplantCategory.Bold:
                    return instanceCache.TryGetBoldBooster(out booster);
                case BoosterImplantCategory.Muted:
                    return instanceCache.TryGetMutedBooster(out booster);
                case BoosterImplantCategory.Aggressive:
                    return instanceCache.TryGetAggressiveBooster(out booster);
            }

            throw new KeyNotFoundException($"Key {category}, is not supported!");
        }

        public static void SetBoldBooster(this InstanceCache instanceCache, Booster booster)
        {
            instanceCache.SetInformation(BoldBoosterKey, booster);
        }

        public static bool TryGetBoldBooster(this InstanceCache instanceCache, out Booster boldBooster)
        {
            return instanceCache.TryGetInformation(BoldBoosterKey, out boldBooster);
        }

        public static void SetMutedBooster(this InstanceCache instanceCache, Booster booster)
        {
            instanceCache.SetInformation(MutedBoosterKey, booster);
        }

        public static bool TryGetMutedBooster(this InstanceCache instanceCache, out Booster mutedBooster)
        {
            return instanceCache.TryGetInformation(MutedBoosterKey, out mutedBooster);
        }

        public static void SetAggressiveBooster(this InstanceCache instanceCache, Booster booster)
        {
            instanceCache.SetInformation(AggressiveBoosterKey, booster);
        }

        public static bool TryGetAggressiveBooster(this InstanceCache instanceCache, out Booster aggressiveBooster)
        {
            return instanceCache.TryGetInformation(AggressiveBoosterKey, out aggressiveBooster);
        }

        public static int AddHiddenBooster(this InstanceCache instanceCache, Booster booster)
        {
            _boosterIdCount += 1;
            instanceCache.SetInformation(HiddenBoosterKey + _boosterIdCount, booster);
            return _boosterIdCount;
        }

        public static bool OverwriteHiddenBooster(this InstanceCache instanceCache, int id, Booster booster)
        {
            var key = HiddenBoosterKey + id;
            if(instanceCache.InformationContainsKey(key))
            {
                instanceCache.SetInformation(key, booster);
                return true;
            }

            return false;
        }
    }
}
