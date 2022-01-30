using EndskApi.Api;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using GTFuckingXP.Information.Level;
using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// XPBar Ui Element.
    /// </summary>
    public class XpBar : MonoBehaviour //needs to be a monobehaviour because "Components" caused some problems.
    {
        private RectTransform _xpBar;
        private SpriteRenderer _xpProgressBar;
        private TextMeshPro _textUi;
        
        public XpBar(IntPtr intPtr) : base(intPtr)
        {
            XpBarStuff();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S) && BepInExLoader.TermsOfUsageState == TermsOfUsage.Undecided)
                {
                    BepInExLoader.TermsOfUsage.Value = TermsOfUsage.Accepted.ToString();
                    var xpHandler = CacheApi.GetInstance<XpHandler>();
                    UpdateUiString(CacheApiWrapper.GetActiveLevel(), xpHandler.NextLevel, xpHandler.CurrentTotalXp, CacheApiWrapper.GetCurrentLevelLayout().Header);
                }
            }
        }

        /// <summary>
        /// Updates the stats text on the bottom right of your screen.
        /// </summary>
        /// <param name="currentLevel">The current active stats.</param>
        /// <param name="nextLevel">The stats to receive when reaching next level.</param>
        /// <param name="currentTotalXp">The current total xp.</param>
        public void UpdateUiString(Level currentLevel, Level nextLevel, uint currentTotalXp, string header)
        {
            var stringBuilder = new StringBuilder();
            string statsString;

            if (BepInExLoader.TermsOfUsageState == TermsOfUsage.Undecided)
            {
                stringBuilder.AppendLine($"Please accept or decline the terms of usage in the config file, to remove this message");
                stringBuilder.AppendLine("You can press following keys all at once \"Y\"+\"E\"+\"S\", to accept it now.");
            }

            if (string.IsNullOrEmpty(currentLevel.CustomLevelStatsText))
            {
                if (nextLevel != null)
                {
                    var currentLevelProgression = currentTotalXp - currentLevel.TotalXpRequired;
                    var currentLevelFinish = nextLevel.TotalXpRequired - currentLevel.TotalXpRequired;

                    stringBuilder.AppendLine($"Classname: {header}");
                    stringBuilder.AppendLine($"MaxHP {currentLevel.HealthMultiplier * CacheApiWrapper.GetDefaultMaxHp()} => {nextLevel.HealthMultiplier * CacheApiWrapper.GetDefaultMaxHp()}");
                    stringBuilder.AppendLine($"MD {currentLevel.MeleeDamageMultiplier} => {nextLevel.MeleeDamageMultiplier}");
                    stringBuilder.AppendLine($"WD {currentLevel.WeaponDamageMultiplier} => {nextLevel.WeaponDamageMultiplier}");
                    stringBuilder.AppendLine($"Level {currentLevel.LevelNumber} => {currentLevelProgression} / {currentLevelFinish}");

                    var value = currentLevelProgression / Convert.ToDouble(currentLevelFinish);
                    _xpProgressBar.size = new Vector2((float)(value * 300f), 20f);
                }
                else
                {
                    stringBuilder.AppendLine($"Classname: {header}");
                    stringBuilder.AppendLine($"MaxHP {currentLevel.HealthMultiplier * CacheApiWrapper.GetDefaultMaxHp()}");
                    stringBuilder.AppendLine($"MD {currentLevel.MeleeDamageMultiplier}");
                    stringBuilder.AppendLine($"WD {currentLevel.WeaponDamageMultiplier}");
                    stringBuilder.AppendLine($"Level {currentLevel.LevelNumber}");
                    _xpProgressBar.gameObject.SetActive(false);
                }

                statsString = stringBuilder.ToString();
            }
            else
            {
                stringBuilder.Append(currentLevel.CustomLevelStatsText);
                statsString = stringBuilder.ToString();

                if(nextLevel is null)
                {
                    _xpProgressBar.gameObject.SetActive(false);
                    statsString = string.Format(statsString, $"Level {currentLevel.LevelNumber}");
                }
                else
                {
                    var currentLevelProgression = currentTotalXp - currentLevel.TotalXpRequired;
                    var currentLevelFinish = nextLevel.TotalXpRequired - currentLevel.TotalXpRequired;
                    var value = currentLevelProgression / Convert.ToDouble(currentLevelFinish);
                    _xpProgressBar.size = new Vector2((float)(value * 300f), 20f);

                    statsString = string.Format(statsString, 
                        $"Level {currentLevel.LevelNumber} => {currentLevelProgression} / {currentLevelFinish}");
                }
            }

            _textUi.text = statsString;
            _textUi.ForceMeshUpdate();
        }

        public void HideTextUi()
        {
            _textUi.text = "";
            _textUi.ForceMeshUpdate();
        }

        /// <summary>
        /// Creates the xpbar and registers it.
        /// </summary>
        public void XpBarStuff()
        {
            if(CacheApi.TryGetInstance(out _xpBar, logNotFound: false))
            {
                if(CacheApi.TryGetInstance(out _xpProgressBar, logNotFound: false))
                {
                    if (CacheApi.TryGetInstance(out _textUi, logNotFound: false))
                    {
                        return;
                    }
                }
            }

            var playerstatus = GuiManager.Current.m_playerLayer.m_playerStatus;

            _xpBar = playerstatus.m_health2.gameObject.transform.parent.gameObject.Instantiate<RectTransform>("XpBarRenderer");

            _xpBar.transform.Translate(0, Screen.height * 50f / 2560f, 0);

            _xpBar.Rotate(0, 180, 0);
            _xpBar.localEulerAngles = new Vector3(0, 180, 180);
            _xpBar.anchorMax = new Vector2(-0.5f, 0.7f);
            _xpBar.anchorMin = new Vector2(0f, 0f);
            _xpBar.localScale = new Vector3(3.1f, 1, 1);

            _xpBar.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;

            _xpProgressBar = _xpBar.GetChild(1).GetComponent<SpriteRenderer>();
            _xpProgressBar.size = new Vector2(3, 10);
            _xpProgressBar.color = new Color(255f / 255, 192f / 255f, 203f / 255);

            _textUi = GuiManager.Current.m_watermarkLayer.m_watermark.m_watermarkText.gameObject.Instantiate<TextMeshPro>("XpText");
            _textUi.transform.Translate(new Vector3(-120f, 0f, 0f));

            CacheApi.SaveInstance(_textUi);
            CacheApi.SaveInstance(_xpBar);
            CacheApi.SaveInstance(_xpProgressBar);
        }
    }
}
