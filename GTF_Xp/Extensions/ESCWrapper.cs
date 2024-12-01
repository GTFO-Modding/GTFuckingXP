using BepInEx.Unity.IL2CPP;
using ExtraSyringeCustomization.Utils;
using System.Runtime.CompilerServices;

namespace GTFuckingXP.Extensions
{
    internal class ESCWrapper
    {
        public const string PLUGIN_GUID = "dev.flaff.gtfo.ExtraSyringeCustomization";
        public static bool HasESC { get; }

        static ESCWrapper()
        {
            HasESC = IL2CPPChainloader.Instance.Plugins.ContainsKey(PLUGIN_GUID);
        }

        public static void Init()
        {
            if (HasESC)
                AddRefreshCallbackESC();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void AddRefreshCallbackESC() => MovementMultiplierManager.AddRefreshCallback(OnRefresh);
        private static float OnRefresh() => CacheApiWrapper.GetActiveLevel().CustomScaling.FirstOrDefault(buff => buff.CustomBuff == Enums.CustomScaling.MovementSpeedMultiplier)?.Value ?? 1f;

        public static bool RefreshMovementSpeed()
        {
            if (!HasESC) return false;

            RefreshMovementSpeedESC();
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void RefreshMovementSpeedESC() => MovementMultiplierManager.Refresh();
    }
}
