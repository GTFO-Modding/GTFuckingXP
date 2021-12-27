using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// XPBar Ui Element.
    /// </summary>
    public class XpBar : MonoBehaviour
    {
        private readonly InstanceCache _instanceCache;

        private RectTransform _xpBar;
        private SpriteRenderer _xpProgressBar;
        private TextMeshPro _textUi;
        
        public XpBar(IntPtr intPtr) : base(intPtr)
        {
            _instanceCache = InstanceCache.Instance;

            XpBarStuff();
        }


        public void UpdateUiString(Level currentLevel, Level nextLevel, uint currentTotalXp)
        {
            var stringBuilder = new StringBuilder();

            if (nextLevel != null)
            {
                var currentLevelProgression = currentTotalXp - currentLevel.TotalXpRequired;
                var currentLevelFinish = nextLevel.TotalXpRequired - currentLevel.TotalXpRequired;

                stringBuilder.AppendLine($"MaxHP {currentLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()} => {nextLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()}");
                stringBuilder.AppendLine($"MD {currentLevel.MeleeDamageMultiplier} => {nextLevel.MeleeDamageMultiplier}");
                stringBuilder.AppendLine($"WD {currentLevel.WeaponDamageMultiplier} => {nextLevel.WeaponDamageMultiplier}");
                stringBuilder.AppendLine($"Level {currentLevel.LevelNumber} => {currentLevelProgression} / {currentLevelFinish}");

                var value = currentLevelProgression / Convert.ToDouble(currentLevelFinish);
                _xpProgressBar.size = new Vector2((float)(value * 300f), 20f);
            }
            else
            {
                stringBuilder.AppendLine($"MaxHP {currentLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()}");
                stringBuilder.AppendLine($"MD {currentLevel.MeleeDamageMultiplier}");
                stringBuilder.AppendLine($"WD {currentLevel.WeaponDamageMultiplier}");
                stringBuilder.AppendLine($"Level {currentLevel.LevelNumber}");
                _xpProgressBar.gameObject.SetActive(false);
            }

            _textUi.text = stringBuilder.ToString();
            _textUi.ForceMeshUpdate();
        }

        public void XpBarStuff()
        {
            if(_instanceCache.TryGetInstance(out _xpBar))
            {
                if(_instanceCache.TryGetInstance(out _xpProgressBar))
                {
                    if (_instanceCache.TryGetInstance(out _textUi))
                    {
                        return;
                    }
                }
            }

            var playerstatus = GuiManager.Current.m_playerLayer.m_playerStatus;

            _xpBar = playerstatus.m_health2.gameObject.transform.parent.gameObject.Instantiate<RectTransform>("XpBarRenderer");

            _xpBar.transform.Translate(0, (30 *  1), 0);

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

            _instanceCache.SetInstance(_textUi);
            _instanceCache.SetInstance(_xpBar);
            _instanceCache.SetInstance(_xpProgressBar);
        }
    }
}
