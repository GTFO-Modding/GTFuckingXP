using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using UnityEngine;
using System.Linq;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using Player;
using GTFuckingXP.Enums;
using EndskApi.Api;
using FloatingTextAPI;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// Handles all Xp interactions.
    /// </summary>
    public class XpHandler : MonoBehaviour
    {
        private bool _hasDebuff;
        private float _nextUpdate;

        //TODO List:
        //TODO Blink Mod
        //TODO Blink Mod expansion
        //TODO Incomming Damage scaling
        //TODO class specific weapons

        public XpHandler(IntPtr intPtr) : base(intPtr)
        {  }

        /// <summary>
        /// Gets or sets the total xp you have to this point.
        /// </summary>
        public uint CurrentTotalXp { get; internal set; }

        /// <summary>
        /// Gets the stats for the next level.
        /// </summary>
        public Level NextLevel { get; internal set; }

        /// <summary>
        /// Gets if you're already max level.
        /// </summary>
        public bool IsMaxLevel => NextLevel is null;

        public void Awake()
        {
            if(CacheApiWrapper.TryGetXpStorageData(out var checkpointXpData))
            {
                LogManager.Message("Found old xp storage data!");
                //Old level layout may be changed because of xp dev tools or other future plans :)
                CacheApiWrapper.SetCurrentLevelLayout(checkpointXpData.levelLayout);

                var level0 = checkpointXpData.levelLayout.Levels.First(it => it.LevelNumber == 0);
                NextLevel = checkpointXpData.levelLayout.Levels.FirstOrDefault(it => it.LevelNumber == level0.LevelNumber + 1);
                CacheApiWrapper.SetActiveLevel(level0, false);
                CurrentTotalXp = 0;
                AddXp(new DummyXp(checkpointXpData.totalXp, checkpointXpData.totalXp), default, false);
            }
            else
            {
                var levelLayout = CacheApiWrapper.GetCurrentLevelLayout();
                var newActiveLevel = levelLayout.Levels.First(it => it.LevelNumber == 0);
                NextLevel = levelLayout.Levels.FirstOrDefault(it => it.LevelNumber == newActiveLevel.LevelNumber + 1);
                CurrentTotalXp = 0;
                ChangeCurrentLevel(newActiveLevel, BoosterBuffManager.Instance.GetFittingBoosterBuff(levelLayout.PersistentId, newActiveLevel.LevelNumber));
                CacheApi.GetInstance<XpBar>(CacheApiWrapper.XpModCacheName).UpdateUiString(CacheApiWrapper.GetActiveLevel(), NextLevel, CurrentTotalXp, levelLayout.Header);
            }
            _nextUpdate = Time.time + 300f;
        }

        public void Update()
        {
            if(_nextUpdate < Time.time)
            {
                //TODO call my own webapi, for average xp data.

                _nextUpdate = Time.time + 300f;
            }
        }

        public void AddXp(IXpData xpData, Vector3 xpTextPosition, bool forceDebuffXp = false, string xpPopupColor = "<#F80>")
        {
            uint xpValue = forceDebuffXp || _hasDebuff ? xpData.DebuffXp : xpData.XpGain;

            var levelScalingDecreaseXp = (xpData.LevelScalingXpDecrese * CacheApiWrapper.GetActiveLevel().LevelNumber);
            if(xpValue <= levelScalingDecreaseXp)
            {
                xpValue = 1;
            }
            else
            {
                xpValue = (uint)(xpValue - levelScalingDecreaseXp);
            }

            CurrentTotalXp += xpValue;
            LogManager.Debug($"Giving xp Amount {xpValue}, new total Xp is {CurrentTotalXp}");
            if (!CheckForLevelThresholdReached(xpTextPosition, out var header) && BepInExLoader.XpPopups.Value)
            {

                DamageNumberFactory.CreateFloatingText<FloatingTextBase>(new FloatingXpTextInfo(xpTextPosition, $"{xpPopupColor}{xpValue}XP"));
            }

            CacheApi.GetInstance<XpBar>(CacheApiWrapper.XpModCacheName).UpdateUiString(CacheApiWrapper.GetActiveLevel(), NextLevel, CurrentTotalXp, header);
        }

        /// <summary>
        /// Looks if the next level is reached and sets it, if it was reached.
        /// </summary>
        /// <param name="xpTextPosition">The world position, where this floating level up position should spawn.</param>
        /// <param name="floatingLevelUpMessage">If a floating level up message should appear.</param>
        /// <returns>If a new level got reached when this method got called.</returns>
        public bool CheckForLevelThresholdReached(Vector3 xpTextPosition, out string currentClassName)
        {
            var levels = CacheApiWrapper.GetCurrentLevelLayout();
            currentClassName = levels.Header;
            if (IsMaxLevel)
            {
                return false;
            }

            var oldLevel = CacheApiWrapper.GetActiveLevel();
            var availableLevels = levels.Levels.Where(it => it.LevelNumber > CacheApiWrapper.GetActiveLevel().LevelNumber && it.TotalXpRequired <= CurrentTotalXp);

            if (availableLevels.Count() > 0)
            {
                var newLevel = availableLevels.OrderByDescending(it => it.LevelNumber).First();

                ChangeCurrentLevel(newLevel, BoosterBuffManager.Instance.GetFittingBoosterBuff(levels.PersistentId, newLevel.LevelNumber));
                NextLevel = levels.Levels.FirstOrDefault(it => it.LevelNumber == newLevel.LevelNumber + 1);

                if (BepInExLoader.LvlUpPopups.Value)
                {
                    if (string.IsNullOrEmpty(newLevel.CustomLevelUpPopupText))
                    {
                        DamageNumberFactory.CreateFloatingText<FloatingTextBase>(new FloatingXpTextInfo(xpTextPosition,
                       $"<#f00>LV {newLevel.LevelNumber}\n" +
                       $"HP: +<#f80>{Math.Round((newLevel.HealthMultiplier * CacheApiWrapper.GetDefaultMaxHp()) - (oldLevel.HealthMultiplier * CacheApiWrapper.GetDefaultMaxHp()), 1)}\n" +
                       $"<#f00>MD: <#f80>{Math.Round(newLevel.MeleeDamageMultiplier - oldLevel.MeleeDamageMultiplier, 2)}x \n" +
                       $"<#f00>WD: <#f80>{Math.Round(newLevel.WeaponDamageMultiplier - oldLevel.WeaponDamageMultiplier, 2)}x", 4f));
                    }
                    else
                    {
                        DamageNumberFactory.CreateFloatingText<FloatingTextBase>(new FloatingXpTextInfo(xpTextPosition,
                            newLevel.CustomLevelUpPopupText, 4f));
                    }
                }

                return true;
            }

            return false;
        }

        internal void ChangeCurrentLevel(Level newLevel, BoosterBuffs newBoosterBuff = null)
        {
            CacheApiWrapper.SetActiveLevel(newLevel);
            CacheApiWrapper.SetCurrentBoosterBuff(newBoosterBuff);

            LogManager.Debug("saved information.");

            BoosterBuffManager.Instance.ApplyBoosterEffects(PlayerManager.GetLocalPlayerAgent(), newBoosterBuff);
            NetworkApiXpManager.SendBoosterStatsReached(newBoosterBuff);

            var localDamage = PlayerManager.GetLocalPlayerAgent().Damage;
            var oldMaxHealth = localDamage.HealthMax;
            var newMaxHealth = CacheApiWrapper.GetDefaultMaxHp() * newLevel.HealthMultiplier;

            localDamage.HealthMax = newMaxHealth;
            localDamage.Health += newMaxHealth - oldMaxHealth;

            localDamage.Cast<Dam_PlayerDamageLocal>().UpdateHealthGui();

            ApplySingleUseBuffs(newLevel);
            LogManager.Debug("Pre applying custom scaling effects.");
            CustomScalingBuffManager.ApplyCustomScalingEffects(PlayerManager.GetLocalPlayerAgent(), newLevel.CustomScaling);
        }

        private void ApplySingleUseBuffs(Level reachedLevel)
        {
            var player = PlayerManager.GetLocalPlayerAgent();
            foreach(var singleUseBuff in reachedLevel.LevelUpBonus)
            {
                switch(singleUseBuff.SingleBuff)
                {
                    case SingleBuff.Heal:
                        player.GiveHealth(singleUseBuff.Value);
                        break;
                    case SingleBuff.Desinfect:
                        player.GiveDisinfection(singleUseBuff.Value);
                        break;
                    case SingleBuff.AmmunitionMain:
                        player.GiveAmmoRel(singleUseBuff.Value, 0f, 0f);
                        break;
                    case SingleBuff.AmmunitionSpecial:
                        player.GiveAmmoRel(0f, singleUseBuff.Value, 0f);
                        break;
                    case SingleBuff.AmmunitionTool:
                        player.GiveAmmoRel(0f, 0f, singleUseBuff.Value);
                        break;
                }
            }
        }
    }
}
