using EndskApi.Api;
using GTFO.API;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Information.NetworkingInfo;
using GTFuckingXP.Patches;
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
        private const string _sendXpString = "ThisSeemsLikeItComesFromTheRandomXpMod...";
        private const string _levelStatsDistribution = "ThisSeemsLikeItComesFromTheXpMod";
        private const string _receiveHalfAssedXp = "ThisSeemsLikeItComesFromTheXpModAgain";
        private const string _checkpointReachedString = "YouShouldSaveYourXpStuff";
        private const string _cleanUpCheckpointsString = "YouShouldCleanupCheckpoints";
        private const string _sendBoosterNetworkString = "IHaveReachedBoosterBuffStatus";       

        public static void Setup()
        {
            NetworkAPI.RegisterEvent<GtfoApiXpInfo>(_sendXpString, ReceiveXp);
            NetworkAPI.RegisterEvent<LevelReachedInfo>(_levelStatsDistribution, ReceiveLevelReached);
            NetworkAPI.RegisterEvent<StaticXpInfo>(_receiveHalfAssedXp, ReceiveStaticXp);
            NetworkAPI.RegisterEvent<DummyStruct>(_checkpointReachedString, ReceiveCheckpointReached);
            NetworkAPI.RegisterEvent<DummyStruct>(_cleanUpCheckpointsString, ReceiveCleanupXpCheckpoints);
            NetworkAPI.RegisterEvent<BoosterInfo>(_sendBoosterNetworkString, ReceiveBoosterBuffs);
        }

        public static void ReceiveXp(ulong snetPlayer, GtfoApiXpInfo xpData)
        {
            LogManager.Debug("Received xp networking package");
            if (CacheApi.TryGetInstance(out XpHandler xpHandler))
            {
                xpHandler.AddXp(xpData, new UnityEngine.Vector3(xpData.PositionX, xpData.PositionY, xpData.PositionZ));
            }
        }

        public static void ReceiveStaticXp(ulong snetPlayer, StaticXpInfo xpInfo)
        {
            LogManager.Debug("Received static xp networking package");
            if (CacheApi.TryGetInstance(out XpHandler xpHandler))
            {
                xpHandler.AddXp(xpInfo, xpInfo.Position, false, false);
            }
        }

        public static void ReceiveLevelReached(ulong snetPlayer, LevelReachedInfo levelData)
        {
            if(SNet.TryGetPlayer(snetPlayer, out var snet))
            {
                var playerAgents = PlayerManager.PlayerAgentsInLevel;
                foreach(var player in playerAgents)
                {
                    if(player.PlayerSlotIndex == snet.PlayerSlotIndex())
                    {
                        var newHealth = levelData.HealthMultiplier * CacheApiWrapper.GetDefaultMaxHp();
                        LogManager.Debug($"Setting HP of {player.name} to {newHealth}");
                        player.Damage.HealthMax = newHealth;

                        CacheApiWrapper.GetPlayerToLevelMapping()[player.PlayerSlotIndex] = levelData.LevelNumber;
                    }
                }
            }
        }

        internal static void ReceiveCheckpointReached(ulong snetPlayer, DummyStruct _)
        {
            CheckpointPatches.CreateCheckpointData();
        }

        internal static void ReceiveCleanupXpCheckpoints(ulong snetPlayer, DummyStruct _)
        {
            CheckpointPatches.CheckpointsCleanup();
        }

        internal static void ReceiveBoosterBuffs(ulong snetPlayer, BoosterInfo newInfo)
        {
            if (SNet.TryGetPlayer(snetPlayer, out var snet))
            {
                var playerAgents = PlayerManager.PlayerAgentsInLevel;
                foreach (var player in playerAgents)
                {
                    if (player.PlayerSlotIndex == snet.PlayerSlotIndex())
                    {
                        BoosterBuffManager.Instance.ApplyBoosterEffects(player, newInfo);
                    }
                }
            }
        }

        public static void SendReceiveXp(PlayerAgent receiver, EnemyXp xpData, Vector3 position, bool forceDebuffXp)
        {
            NetworkAPI.InvokeEvent(_sendXpString, new GtfoApiXpInfo(xpData.XpGain, xpData.DebuffXp, xpData.LevelScalingXpDecrese, position, forceDebuffXp),
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

            NetworkAPI.InvokeEvent(_sendXpString, new GtfoApiXpInfo(xpData.XpGain, xpData.DebuffXp, xpData.LevelScalingXpDecrese, position, forceDebuffXp),
                players);
        }

        public static void SendNewLevelActive(Level newLevel)
        {
            NetworkAPI.InvokeEvent(_levelStatsDistribution, new LevelReachedInfo(newLevel));
        }

        public static void SendBoosterStatsReached(BoosterInfo boosterInfo)
        {
            NetworkAPI.InvokeEvent(_sendBoosterNetworkString, boosterInfo);
        }

        public static void SendStaticXpInfo(PlayerAgent receiver, uint xpGain, uint debuffXp, int levelScalingDecrease, Vector3 position)
        {
            NetworkAPI.InvokeEvent(_receiveHalfAssedXp, new StaticXpInfo(xpGain, debuffXp, levelScalingDecrease, position), receiver.Owner);
        }

        public static void SendLevelReached()
        {
            List<SNet_Player> players = new List<SNet_Player>();
            foreach (var snet in SNet.LobbyPlayers)
            {
                if (!snet.IsLocal)
                {
                    players.Add(snet);
                }
            }

            NetworkAPI.InvokeEvent<DummyStruct>(_checkpointReachedString, default, players);
        }

        public static void SendCheckpointReached()
        {
            NetworkAPI.InvokeEvent(_checkpointReachedString, new DummyStruct());
        }

        public static void SendCheckpointCleanups()
        {
            NetworkAPI.InvokeEvent(_cleanUpCheckpointsString, new DummyStruct());

        }

        internal struct DummyStruct
        { }
    }
}
