using CustomBoostersXp.Information.BoosterInfo;
using EndskApi.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBoostersXp.Extensions
{
    public static class CacheApiWrapperBooster
    {
        private const string BoldBoosterKey = "BoldBoosterKey";
        private const string MutedBoosterKey = "MutedBoosterKey";
        private const string AggressiveBoosterKey = "AggressiveBoosterKey";

        private const string HiddenBoosterKey = "HiddenBooster";

        private static int _boosterIdCount = 0;

        internal static int SetBooster(Booster booster)
        {
            switch (booster.Category)
            {
                case BoosterImplantCategory.Bold:
                    SetBoldBooster(booster);
                    return -1;
                case BoosterImplantCategory.Muted:
                    SetMutedBooster(booster);
                    return -1;
                case BoosterImplantCategory.Aggressive:
                    SetAggressiveBooster(booster);
                    return -1;
            }

            return AddHiddenBooster(booster);
        }

        internal static bool TryGetBooster(BoosterImplantCategory category, out Booster booster)
        {
            switch (category)
            {
                case BoosterImplantCategory.Bold:
                    return TryGetBoldBooster(out booster);
                case BoosterImplantCategory.Muted:
                    return TryGetMutedBooster(out booster);
                case BoosterImplantCategory.Aggressive:
                    return TryGetAggressiveBooster(out booster);
            }

            throw new KeyNotFoundException($"Key {category}, is not supported!");
        }

        public static void SetBoldBooster(Booster booster)
        {
            CacheApi.SaveInformation(BoldBoosterKey, booster);
        }

        public static bool TryGetBoldBooster(out Booster boldBooster)
        {
            return CacheApi.TryGetInformation(BoldBoosterKey, out boldBooster);
        }

        public static void SetMutedBooster(Booster booster)
        {
            CacheApi.SaveInformation(MutedBoosterKey, booster);
        }

        public static bool TryGetMutedBooster(out Booster mutedBooster)
        {
            return CacheApi.TryGetInformation(MutedBoosterKey, out mutedBooster);
        }

        public static void SetAggressiveBooster(Booster booster)
        {
            CacheApi.SaveInformation(AggressiveBoosterKey, booster);
        }

        public static bool TryGetAggressiveBooster(out Booster aggressiveBooster)
        {
            return CacheApi.TryGetInformation(AggressiveBoosterKey, out aggressiveBooster);
        }

        public static int AddHiddenBooster(Booster booster)
        {
            _boosterIdCount += 1;
            CacheApi.SaveInformation(HiddenBoosterKey + _boosterIdCount, booster);
            return _boosterIdCount;
        }

        public static bool OverwriteHiddenBooster(int id, Booster booster)
        {
            var key = HiddenBoosterKey + id;
            if (CacheApi.ContainsKey(key))
            {
                CacheApi.SaveInformation(key, booster);
                return true;
            }

            return false;
        }
    }
}
