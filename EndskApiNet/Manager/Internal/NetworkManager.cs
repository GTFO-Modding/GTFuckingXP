using EndskApi.Api;
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

        internal struct DummyStruct
        { }
    }
}
