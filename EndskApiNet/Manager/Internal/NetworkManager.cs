using EndskApi.Api;
using EndskApi.Information.WeaponSwitcher;
using GTFO.API;

namespace EndskApi.Manager.Internal
{
    internal static class NetworkManager
    {
        private const string _sendCheckpointReachedKey = "CheckpointHasBeenReached";
        private const string _sendCheckpointCleanupKey = "CheckpointCleanup";

        public static void Setup()
        {
            NetworkAPI.RegisterEvent<DummyStruct>(_sendCheckpointCleanupKey, ReceiveCheckpointCleanup);
            NetworkAPI.RegisterEvent<DummyStruct>(_sendCheckpointReachedKey, ReceiveCheckpointReached);
        }

        private static void ReceiveCheckpointReached(ulong snetPlayer, DummyStruct _)
        {
            CheckpointApi.InvokeCheckpointReachedCallbacks();
        }

        private static void ReceiveCheckpointCleanup(ulong snetPlayer, DummyStruct _)
        {
            CheckpointApi.InvokeCheckpointCleanupCallbacks();
        }

        public static void SendCheckpointReached()
        {
            NetworkAPI.InvokeEvent(_sendCheckpointReachedKey, new DummyStruct());
        }

        public static void SendCheckpointCleanups()
        {
            NetworkAPI.InvokeEvent(_sendCheckpointCleanupKey, new DummyStruct());
        }

        public static void SendEquipGear(GearInfo info)
        {

        }

        internal struct DummyStruct
        { }

        internal struct EquipGearStruct
        {

        }
    }
}
