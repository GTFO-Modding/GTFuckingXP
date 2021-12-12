using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using UnityEngine;
using System.Linq;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using Player;
using DamageNumbers;
using DamageNumbers.API;
using GTFuckingXP.Enums;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// Handles all Xp interactions.
    /// </summary>
    public class XpHandler : MonoBehaviour
    {
        private readonly InstanceCache _instanceCache = InstanceCache.Instance;
        private readonly bool _devMode;

        private bool _hasDebuff;

        public XpHandler(IntPtr intPtr) : base(intPtr)
        {
            _devMode = BepInExLoader.RundownDevMode.Value;
        }

        /// <summary>
        /// Gets or sets the total xp you have to this point.
        /// </summary>
        public uint CurrentTotalXp { get; internal set; }

        /// <summary>
        /// Gets the stats for the next level.
        /// </summary>
        public Level NextLevel { get; private set; }

        /// <summary>
        /// Gets if you're already max level.
        /// </summary>
        public bool IsMaxLevel => NextLevel is null;

        public void Awake()
        {
            var levelLayout = _instanceCache.GetCurrentLevelLayout();
            LogManager.Debug("GetCurrentLevelLayout ran through.");
            var newActiveLevel = levelLayout.Levels.First(it => it.LevelNumber == 0);
            _instanceCache.SetActiveLevel(newActiveLevel);
            NextLevel = levelLayout.Levels.FirstOrDefault(it => it.LevelNumber == newActiveLevel.LevelNumber + 1);
            CurrentTotalXp = 0;
        }

        public void AddXp(IXpData xpData, Vector3 xpTextPosition, bool forceDebuffXp = false, bool floatingText = true)
        {
            uint xpValue = forceDebuffXp || _hasDebuff ? xpData.DebuffXp : xpData.XpGain;

            var levelScalingDecreaseXp = (xpData.LevelScalingXpDecrese * _instanceCache.GetActiveLevel().LevelNumber);
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
            if(!CheckForLevelThresholdReached(xpTextPosition, floatingText) && floatingText)
            {
                LogManager.Debug("Creating Floating Text xp stuff.");
                DamageNumberFactory.CreateFloatingText<FloatingTextBase>(new FloatingXpTextInfo(xpTextPosition, $"<#F80>{xpValue}XP"));
            }

            _instanceCache.GetInstance<XpBar>().UpdateUiString(_instanceCache.GetActiveLevel(), NextLevel, CurrentTotalXp);
        }
        
        /// <summary>
        /// Looks if the next level is reached and sets it, if it was reached.
        /// </summary>
        /// <param name="xpTextPosition">The world position, where this floating level up position should spawn.</param>
        /// <param name="floatingLevelUpMessage">If a floating level up message should appear.</param>
        /// <returns>If a new level got reached when this method got called.</returns>
        public bool CheckForLevelThresholdReached(Vector3 xpTextPosition, bool floatingLevelUpMessage = true)
        {
            var levels = _instanceCache.GetCurrentLevelLayout();
            var oldLevel = _instanceCache.GetActiveLevel();

            var availableLevels = levels.Levels.Where(it => it.LevelNumber > _instanceCache.GetActiveLevel().LevelNumber && it.TotalXpRequired <= CurrentTotalXp);

            if(availableLevels.Count() > 0)
            {
                foreach(var level in availableLevels)
                {
                    LogManager.Debug($"Level with number {level.LevelNumber}, was available");
                }
                var newLevel = availableLevels.OrderByDescending(it => it.LevelNumber).First();
                LogManager.Debug($"Choose, level with the number{newLevel.LevelNumber}");

                ChangeCurrentLevel(newLevel);

                NextLevel = levels.Levels.FirstOrDefault(it => it.LevelNumber == newLevel.LevelNumber + 1);
                //LogManager.Debug($"NextLevel is number: {NextLevel.LevelNumber} and xp required is {NextLevel.TotalXpRequired}");

                DamageNumberFactory.CreateFloatingText<FloatingTextBase>(new FloatingXpTextInfo(xpTextPosition, 
                    $"<#f00>LV {newLevel.LevelNumber}\n" + 
                    $"HP: +<#f80>{Math.Round((newLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()) - (oldLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()), 1)}\n" +
                    $"<#f00>MD: <#f80>{Math.Round(newLevel.MeleeDamageMultiplier - oldLevel.MeleeDamageMultiplier, 2)}x \n" +
                    $"<#f00>WD: <#f80>{Math.Round(newLevel.WeaponDamageMultiplier - oldLevel.WeaponDamageMultiplier, 2)}x", 4f));

                return true;
            }

            return false;
        }

        private IXpData _testData = new EnemyXp(0, "", 20, 20, 0);

        public void Update()
        {
            if(Input.GetKey(KeyCode.KeypadPlus) && _devMode)
            {
                AddXp(_testData, PlayerManager.GetLocalPlayerAgent().Position);
            }
        }

        private void ChangeCurrentLevel(Level newLevel)
        {
            _instanceCache.SetActiveLevel(newLevel);
            var localDamage = PlayerManager.GetLocalPlayerAgent().Damage;
            var oldMaxHealth = localDamage.HealthMax;
            var newMaxHealth = _instanceCache.GetDefaultMaxHp() * newLevel.HealthMultiplier;

            localDamage.HealthMax = newMaxHealth;
            localDamage.Health += newMaxHealth - oldMaxHealth;

            localDamage.Cast<Dam_PlayerDamageLocal>().UpdateHealthGui();

            ApplySingleUseBuffs(newLevel);
        }

        private void ApplySingleUseBuffs(Level reachedLevel)
        {
            var player = PlayerManager.GetLocalPlayerAgent();
            foreach(var singleUseBuff in reachedLevel.SingleUseBuffs)
            {
                switch(singleUseBuff.SingleBuff)
                {
                    case SingleBuff.Heal:
                        player.GiveHealth(singleUseBuff.Value);
                        break;
                    case SingleBuff.Desinfect:
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
