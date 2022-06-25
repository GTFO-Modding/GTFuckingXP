using EndskApi.Api;
using GTFO.API;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Information.NetworkingInfo;
using GTFuckingXP.Scripts;
using Player;
using SNetwork;
using System.Text.Json;
using UnityEngine;

namespace GTFuckingXP.Managers
{
    /// <summary>
    /// Handles all interactions with the GtfoApi networking interactions.
    /// </summary>
    public static class NetworkApiXpManager
    {
        private const string _sendXpString = "ThisSeemsLikeItComesFromTheRandomXpMod...";
        private const string _levelStatsDistribution = "ReachedSentLevel_XP";
        private const string _receiveStaticXp = "XpModTriesToGiveYouSomeHalfAssedXP";
        private const string _undistributedXp = "XpModGivesYouSomeXpWhereYouHadNotToDoAnything";
        private const string _sendBoosterNetworkString = "MyNewBoostersEffectFromTheXpMod";       

        public static void Setup()
        {
            NetworkAPI.RegisterEvent<GtfoApiXpInfo>(_sendXpString, ReceiveXp);
            NetworkAPI.RegisterEvent<LevelReachedInfo>(_levelStatsDistribution, ReceiveLevelReached);
            NetworkAPI.RegisterEvent<StaticXpInfo>(_receiveStaticXp, ReceiveStaticXp);
            NetworkAPI.RegisterEvent<BoosterInfo>(_sendBoosterNetworkString, ReceiveBoosterBuffs);
            NetworkAPI.RegisterEvent<GtfoApiXpInfo>(_undistributedXp, ReceiveHalfAssedXp);
        }

        public static void ReceiveXp(ulong snetPlayer, GtfoApiXpInfo xpData)
        {
            LogManager.Debug("Received xp networking package");
            if (CacheApi.TryGetInstance(out XpHandler xpHandler, CacheApiWrapper.XpModCacheName))
            {
                xpHandler.AddXp(xpData, new UnityEngine.Vector3(xpData.PositionX, xpData.PositionY, xpData.PositionZ));
            }
        }

        public static void ReceiveHalfAssedXp(ulong snetPlayer, GtfoApiXpInfo xpData)
        {
            if (CacheApi.TryGetInstance(out XpHandler xpHandler, CacheApiWrapper.XpModCacheName))
            {
                xpHandler.AddXp(xpData, new UnityEngine.Vector3(xpData.PositionX, xpData.PositionY, xpData.PositionZ), xpData.ForceDebuffXp, "<#888>");
            }
        }

        public static void ReceiveStaticXp(ulong snetPlayer, StaticXpInfo xpInfo)
        {
            LogManager.Debug("Received static xp networking pckage");
            if (CacheApi.TryGetInstance(out XpHandler xpHandler, CacheApiWrapper.XpModCacheName))
            {
                xpHandler.AddXp(xpInfo, xpInfo.Position, false, "<#F30>");
            }
        }

        public static void ReceiveLevelReached(ulong snetPlayer, LevelReachedInfo levelData)
        {
            LogManager.Debug("Receive level reached info");
            if(SNet.TryGetPlayer(snetPlayer, out var snet))
            {
                var playerAgents = PlayerManager.PlayerAgentsInLevel;
                foreach(var player in playerAgents)
                {
                    if(player.PlayerSlotIndex == snet.PlayerSlotIndex())
                    {
                        Level level = new Level(levelData);

                        var newHealth = level.HealthMultiplier * CacheApiWrapper.GetDefaultMaxHp();
                        LogManager.Debug($"Setting HP of {player.name} to {newHealth}");
                        player.Damage.HealthMax = newHealth;

                        CustomScalingBuffManager.ApplyCustomScalingEffects(player, level.CustomScaling);
                        CacheApiWrapper.GetPlayerToLevelMapping()[player.PlayerSlotIndex] = level;
                    }
                }
            }
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

        public static void SendHalfAssedXp(EnemyXp xpData, Vector3 position, bool forceDebuffXp)
        {
            NetworkAPI.InvokeEvent(_undistributedXp, new GtfoApiXpInfo(xpData.XpGain, xpData.DebuffXp, xpData.LevelScalingXpDecrese, position, forceDebuffXp));
        }

        public static void SendNewLevelActive(Level newLevel)
        {
            var customScaling = JsonSerializer.Serialize((
                    newLevel.CustomScaling is null ?
                    new List<CustomScalingBuff>() :
                    newLevel.CustomScaling));
            NetworkAPI.InvokeEvent(_levelStatsDistribution, new LevelReachedInfo(newLevel.LevelNumber, newLevel.HealthMultiplier, customScaling));
        }

        public static void SendBoosterStatsReached(BoosterInfo boosterInfo)
        {
            NetworkAPI.InvokeEvent(_sendBoosterNetworkString, boosterInfo);
        }

        public static void SendStaticXpInfo(PlayerAgent receiver, uint xpGain, uint debuffXp, int levelScalingDecrease, Vector3 position)
        {
            NetworkAPI.InvokeEvent(_receiveStaticXp, new StaticXpInfo(xpGain, debuffXp, levelScalingDecrease, position), receiver.Owner);
        }
    }
}
