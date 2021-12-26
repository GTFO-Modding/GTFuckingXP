using GTFO.API;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.NetworkingInfo;
using GTFuckingXP.Scripts;
using Player;
using SNetwork;
using System.Collections.Generic;
using UnityEngine;

namespace GTFuckingXP.Managers
{
    /// <summary>
    /// Handles all interactions with the GtfoApi networking interactions.
    /// </summary>
    public static class NetworkApiXpManager
    {
        private const string _XpNetworkString = "ThisSeemsLikeItComesFromTheRandomXpMod...";

        private static readonly ScriptManager _scriptManager;
        private static readonly InstanceCache _instanceCache;

        static NetworkApiXpManager()
        {
            _instanceCache = InstanceCache.Instance;
            _scriptManager = ScriptManager.Instance;
        }

        public static void Setup()
        {
            NetworkAPI.RegisterEvent<GtfoApiXpInfo>(_XpNetworkString, ReceiveXp);
        }

        public static void ReceiveXp(ulong snetPlayer, GtfoApiXpInfo xpData)
        {
            LogManager.Debug("Received xp networking package");
            if (_instanceCache.TryGetInstance(out XpHandler xpHandler))
            {
                xpHandler.AddXp(xpData, new UnityEngine.Vector3(xpData.PositionX, xpData.PositionY, xpData.PositionZ));
            }
        }

        public static void SendReceiveXp(PlayerAgent receiver, EnemyXp xpData, Vector3 position, bool forceDebuffXp)
        {
            NetworkAPI.InvokeEvent(_XpNetworkString, new GtfoApiXpInfo(xpData.XpGain, xpData.DebuffXp, xpData.LevelScalingXpDecrese, position, forceDebuffXp),
                receiver.Owner);
        }

        public static void SendReceiveXpToEveryone(EnemyXp xpData, Vector3 position, bool forceDebuffXp)
        {
            List<SNet_Player> players = new List<SNet_Player>();
            foreach(var snet in SNet.LobbyPlayers)
            {
                if(!snet.IsLocal)
                {
                    players.Add(snet);
                }
            }

            NetworkAPI.InvokeEvent(_XpNetworkString, new GtfoApiXpInfo(xpData.XpGain, xpData.DebuffXp, xpData.LevelScalingXpDecrese, position, forceDebuffXp),
                players);
        }
    }
}
