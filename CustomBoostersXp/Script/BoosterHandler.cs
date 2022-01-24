using CustomBoostersXp.Extensions;
using CustomBoostersXp.Information.BoosterInfo;
using GTFuckingXP.Managers;

namespace CustomBoostersXp.Script
{
    public class BoosterHandler
    {
        private readonly InstanceCache _instanceCache;

        public BoosterHandler()
        {
            _instanceCache = InstanceCache.Instance;
        }

        public int AddBooster(Booster booster)
        {
            _instanceCache.SetBooster(booster);
        }

        public void 
    }
}
