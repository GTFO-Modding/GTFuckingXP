using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using UnityEngine;
using System.Linq;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using Player;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// Handles all Xp interactions.
    /// </summary>
    public class XpHandler : MonoBehaviour
    {
        private readonly InstanceCache _instanceCache = InstanceCache.Instance;

        private bool _hasDebuff;

        public XpHandler(IntPtr intPtr) : base(intPtr)
        { }

        /// <summary>
        /// Gets or sets the total xp you have to this point.
        /// </summary>
        public uint CurrentTotalXp { get; private set; }

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

        public void AddXp(IXpData enemyKill, bool forceDebuffXp = false)
        {
            uint xpValue = forceDebuffXp || _hasDebuff ? enemyKill.XpGain : enemyKill.DebuffXp;

            var levelScalingDecreaseXp = (enemyKill.LevelScalingXpDecrese * _instanceCache.GetActiveLevel().LevelNumber);
            if(xpValue < levelScalingDecreaseXp)
            {
                xpValue = 1;
            }
            else
            {
                xpValue = (uint)(xpValue - levelScalingDecreaseXp);
            }

            CurrentTotalXp += xpValue;
            LogManager.Debug($"Giving xp Amount {xpValue}, new total Xp is {CurrentTotalXp}");
            CheckForLevelThresholdReached();

            _instanceCache.GetInstance<XpBar>().UpdateUiString(_instanceCache.GetActiveLevel(), NextLevel, CurrentTotalXp);
        }
        
        public void CheckForLevelThresholdReached()
        {
            var levels = _instanceCache.GetCurrentLevelLayout();

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
            }
        }

        private IXpData _testData = new EnemyXp(0, "", 20, 20, 0);

        public void Update()
        {
            if(Input.GetKey(KeyCode.P))
            {
                AddXp(_testData);
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
        }
    }
}
