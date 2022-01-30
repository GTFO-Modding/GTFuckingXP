using EndskApi.Api;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GTFuckingXP.Extensions
{
    /// <summary>
    /// Provides extensions methods for <see cref="CacheApi"/>.
    /// </summary>
    public static class CacheApiWrapper
    {
        public const string XpModCacheName = "GTF_XP";

        internal const string LevelLayoutKey = "LevelLayout";
        internal const string CheckpointData = "XpCheckpointData";
        private const string ActiveLevelKey = "ActiveLevel";
        private const string DefaultDataBlockMaxHpKey = "MaxHpDefault";
        private const string PlayerSlotToLevelIndexMappingKey = "PlayerLevelIndexMapping";
        private const string BoosterBuffKey = "BoosterBuffKey";
        private const string AnchorDifferenceKey = "AnchorDifferenceKey";
        private const string LvlUpCallbackKey = "LvlUpCallbackKey";

        private const string DefaultMeleeRangeKey = "DefaultMeleeRangeKey";
        private const string DefaultMeleeHitBoxKey = "DefaultMeleeHitBoxKey";
        private const string DefaultMovmentKey = "DefaultMovmentKeys";

        /// <summary>
        /// Creates a new component of type <typeparamref name="Tscript"/> and saves it into the cache.
        /// Returns the newly created <typeparamref name="Tscript"/> after this.
        /// </summary>
        /// <typeparam name="Tscript">The component that should be created and cached.</typeparam>
        public static Tscript DestroyOldCreateRegisterAndReturnComponent<Tscript>() where Tscript : Component
        {
            if (CacheApi.TryGetInstance<Tscript>(out var instance))
            {
                instance.gameObject.SetActive(false);
                UnityEngine.Object.Destroy(instance);
                CacheApi.RemoveInstance<Tscript>();
            }

            var gameObject = new GameObject("GetTheFuckingXp_Endskill");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            instance = gameObject.AddComponent<Tscript>();

            CacheApi.SaveInstance(instance);
            return instance;
        }

        /// <summary>
        /// Create a new component of type <typeparamref name="Tscript"/> and registers if it is not already registered.
        /// </summary>
        /// <typeparam name="Tscript">The component that should be created and registered if it does not exist yet.</typeparam>
        public static Tscript CreateRegisterAndReturnComponent<Tscript>() where Tscript : Component
        {
            if (CacheApi.TryGetInstance<Tscript>(out var instance))
            {
                instance.gameObject.SetActive(true);
                return instance;
            }

            var gameObject = new GameObject("GetTheFuckingXp_Endskill");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            instance = gameObject.AddComponent<Tscript>();

            CacheApi.SaveInstance(instance);
            return instance;
        }

        /// <summary>
        /// Kills the cached <typeparamref name="Tscript"/> component if it exists.
        /// </summary>
        public static void KillScript<Tscript>() where Tscript : Component
        {
            if (CacheApi.TryGetInstance<Tscript>(out var script))
            {
                script.gameObject.SetActive(false);
                UnityEngine.Object.Destroy(script);
                CacheApi.RemoveInstance<Tscript>();
            }
        }

        public static void SetCurrentLevelLayout(LevelLayout levelLayout)
        {
            LogManager.Debug($"Set current level layout to {levelLayout.Header}.");
            CacheApi.SaveInformation(LevelLayoutKey, levelLayout);
        }

        public static LevelLayout GetCurrentLevelLayout()
        {
            return CacheApi.GetInformation<LevelLayout>(LevelLayoutKey);
        }

        public static bool TryGetCurrentLevelLayout(out LevelLayout levelLayout)
        {
            return CacheApi.TryGetInformation(LevelLayoutKey, out levelLayout);
        }

        /// <summary>
        /// Sets the new current active level to <paramref name="newLevel"/>
        /// </summary>
        public static void SetActiveLevel(Level newLevel, bool sendToOtherPeople = true)
        {
            LogManager.Debug($"Setting new level to {newLevel.LevelNumber}.");
            if (sendToOtherPeople)
            {
                NetworkApiXpManager.SendNewLevelActive(newLevel);
            }
            CacheApi.SaveInformation(ActiveLevelKey, newLevel);
        }

        /// <summary>
        /// Gets the current level with all stats.
        /// </summary>
        public static Level GetActiveLevel()
        {
            return CacheApi.GetInformation<Level>(ActiveLevelKey);
        }

        public static float GetDefaultMaxHp()
        {
            return CacheApi.GetInformation<float>(DefaultDataBlockMaxHpKey);
        }

        /// <summary>
        /// Sets the default HP.
        /// </summary>
        public static void SetDefaultMaxHp(float defaultMaxHp)
        {
            CacheApi.SaveInformation(DefaultDataBlockMaxHpKey, defaultMaxHp);
        }

        /// <summary>
        /// Sets the player to index map dictionary in the <paramref name="instanceCache"/>.
        /// </summary>
        public static void SetPlayerToLevelMapping(Dictionary<int, Level> playerToLevelMap)
        {
            CacheApi.SaveInformation(PlayerSlotToLevelIndexMappingKey, playerToLevelMap);
        }

        public static Dictionary<int, Level> GetPlayerToLevelMapping()
        {
            return CacheApi.GetInformation<Dictionary<int, Level>>(PlayerSlotToLevelIndexMappingKey);
        }

        public static void SetXpStorageData(uint knownXpState)
        {
            CacheApi.SaveInformation(CheckpointData, (GetCurrentLevelLayout(), knownXpState));
        }

        public static bool TryGetXpStorageData(out (LevelLayout levelLayout, uint totalXp) checkpointData)
        {
            return CacheApi.TryGetInformation(CheckpointData, out checkpointData);
        }

        public static BoosterBuffs GetCurrentBoosterBuffs()
        {
            return CacheApi.GetInformation<BoosterBuffs>(BoosterBuffKey);
        }

        public static void SetCurrentBoosterBuff(BoosterBuffs boosterBuff)
        {
            CacheApi.SaveInformation(BoosterBuffKey, boosterBuff);
        }

        public static void SetAnchorDifference(float anchorDifference)
        {
            CacheApi.SaveInformation(AnchorDifferenceKey, anchorDifference);
        }

        public static bool TryGetAnchorDifference(out float anchorDifference)
        {
            return CacheApi.TryGetInformation(AnchorDifferenceKey, out anchorDifference);
        }

        public static void SetLvlUpCallBackList(List<Action<int>> lvlUpCallbacks)
        {
            CacheApi.SaveInformation(LvlUpCallbackKey, lvlUpCallbacks);
        }

        public static void AddLvlUpCallback(Action<int> lvlUpCallback)
        {
            CacheApi.GetInformation<List<Action<int>>>(LvlUpCallbackKey).Add(lvlUpCallback);
        }

        public static bool RemoveLvlUpCallback(Action<int> lvlUpCallback)
        {
            return CacheApi.GetInformation<List<Action<int>>>(LvlUpCallbackKey).Remove(lvlUpCallback);
        }

        public static void SetDefaultMeleeRange(float meleeRange)
        {
            CacheApi.SaveInformation(DefaultMeleeRangeKey, meleeRange);
        }

        public static void RemoveDefaultMeleeRange()
        {
            CacheApi.RemoveInformation(DefaultMeleeRangeKey);
        }

        public static bool TryGetDefaultMeleeRange(out float meleeRange)
        {
            return CacheApi.TryGetInformation(DefaultMeleeRangeKey, out meleeRange);
        }

        public static void SetDefaultMeleeHitBox(float meleeHitbox)
        {
            CacheApi.SaveInformation(DefaultMeleeHitBoxKey, meleeHitbox);
        }

        public static void RemoveDefaultMeleeHitBox()
        {
            CacheApi.RemoveInformation(DefaultMeleeHitBoxKey);
        }

        public static bool TryGetDefaultMeleeHitBox(out float meleeHitbox)
        {
            return CacheApi.TryGetInformation(DefaultMeleeHitBoxKey, out meleeHitbox);
        }


        public static bool TryGetDefaultMovment(out (float walk, float run, float air, float crouch) movmentData)
        {
            return CacheApi.TryGetInformation(DefaultMovmentKey, out movmentData);
        }

        public static void SetDefaultMovment(float walk, float run, float air, float crouch)
        {
            CacheApi.SaveInformation(DefaultMovmentKey, (walk, run, air, crouch));
        }
    }
}
