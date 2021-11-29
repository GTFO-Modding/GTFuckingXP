using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using UnityEngine;
using System.Linq;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using Player;
using static UnityEngine.GUI;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// Handles all Xp interactions.
    /// </summary>
    public class XpHandler : MonoBehaviour
    {
        private readonly InstanceCache _instanceCache = InstanceCache.Instance;

        private readonly Rect _position1;
        private readonly Rect _position2;
        private readonly Rect _position3;
        private readonly Rect _position4;
        private readonly Rect _position5;

        private string _levelString1;
        private string _levelString2;
        private string _levelString3;
        private string _levelString4;
        private string _levelString5;

        private bool _hasDebuff;

        public XpHandler(IntPtr intPtr) : base(intPtr)
        {
            var xpBarPosition = _instanceCache.GetInstance<XpBar>().XpBarLocalPosition;

            _position1 = new Rect(xpBarPosition.x, xpBarPosition.y + 200, 300, 30);
            _position2 = new Rect(xpBarPosition.x, xpBarPosition.y + 170, 300, 30);
            _position3 = new Rect(xpBarPosition.x, xpBarPosition.y + 140, 300, 30);
            _position4 = new Rect(xpBarPosition.x, xpBarPosition.y + 110, 300, 30);
            _position5 = new Rect(xpBarPosition.x, xpBarPosition.y + 80, 300, 30);
        }

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

        ///// <summary>
        ///// Gets the single instance of <see cref="XpBar"/>.
        ///// </summary>
        //protected XpBar XpBarInstance
        //{
        //    get
        //    {
        //        XpBar bar;
        //        if (!_instanceCache.TryGetinstance(out bar))
        //        {
        //            bar = GuiManager.Current.m_playerLayer.m_playerStatus.gameObject.AddComponent<XpBar>();
        //            _instanceCache.SetInstance(bar);
        //        }
        //        return bar;
        //    }
        //}

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

            ChangeUiStrings();
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
            }
        }

        private IXpData _testData = new EnemyXp(0, "", 20, 20, 0);

        private XpBar _xpBar;

        public void Update()
        {
            if(Input.GetKey(KeyCode.P))
            {
                AddXp(_testData);
            }
        }

        public void OnGUI()
        {
            GUI.Window(100, new Rect(0, 0, Screen.width, Screen.height), (WindowFunction)Ui, "");
        }

        private void Ui(int windowId)
        {
            GUI.Label(_position1, _levelString1);
            GUI.Label(_position2, _levelString2);
            GUI.Label(_position3, _levelString3);
            GUI.Label(_position4, _levelString4);
            GUI.Label(_position5, _levelString5);
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

        private void ChangeUiStrings()
        {
            var currentLevel = _instanceCache.GetActiveLevel();
            _levelString1 = $"Level {currentLevel.LevelNumber}";
            _levelString2 = $"MaxHP {currentLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()} => {NextLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()}";
            _levelString3 = $"MD {currentLevel.MeleeDamageMultiplier} => {NextLevel.MeleeDamageMultiplier}";
            _levelString4 = $"WD {currentLevel.WeaponDamageMultiplier} => {NextLevel.WeaponDamageMultiplier}";
            _levelString5 = $"XP {CurrentTotalXp - currentLevel.TotalXpRequired} / {NextLevel.TotalXpRequired / currentLevel.TotalXpRequired}";
        }
    }
}
