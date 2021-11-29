﻿using BepInEx.IL2CPP;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using System.Text;
using UnityEngine;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// XPBar Ui Element.
    /// </summary>
    public class XpBar : MonoBehaviour
    {
        private static string _prefix;
        private readonly InstanceCache _instanceCache;

        private RectTransform _xpBar;
        private SpriteRenderer _xpProgressBar;
        
        static XpBar()
        { }

        public XpBar(IntPtr intPtr) : base(intPtr)
        {
            _instanceCache = InstanceCache.Instance;

            XpBarStuff();
        }


        public void UpdateUiString(Level currentLevel, Level nextLevel, uint currentTotalXp)
        {
            if(string.IsNullOrEmpty(_prefix))
            {
                _prefix = GuiManager.Current.m_watermarkLayer.m_watermark.m_watermarkText.text;
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_prefix);
            stringBuilder.AppendLine($"MaxHP {currentLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()} => {nextLevel.HealthMultiplier * _instanceCache.GetDefaultMaxHp()}");
            stringBuilder.AppendLine($"MD {currentLevel.MeleeDamageMultiplier} => {nextLevel.MeleeDamageMultiplier}");
            stringBuilder.AppendLine($"WD {currentLevel.WeaponDamageMultiplier} => {nextLevel.WeaponDamageMultiplier}");
            stringBuilder.AppendLine($"Level :{currentLevel.LevelNumber} => {currentTotalXp - currentLevel.TotalXpRequired} / {nextLevel.TotalXpRequired / currentLevel.TotalXpRequired}");

            GuiManager.Current.m_watermarkLayer.m_watermark.m_watermarkText.SetText(stringBuilder.ToString());
            GuiManager.Current.m_watermarkLayer.m_watermark.m_watermarkText.ForceMeshUpdate();

            //TODO NextLevel can be null!!!!
        }

        public void XpBarStuff()
        {
            if (_xpBar != null)
                Destroy(_xpBar);

            bool oxygenPluginExists = false;
            if (IL2CPPChainloader.Instance.Plugins.TryGetValue("com.chasetug.Oxygen", out var info))
            {
                oxygenPluginExists = true;
            }

            var playerstatus = GuiManager.Current.m_playerLayer.m_playerStatus;

            _xpBar = playerstatus.m_health2.gameObject.transform.parent.gameObject.Instantiate<RectTransform>("XpBarRenderer");

            _xpBar.transform.Translate(0, (float)(30 * (oxygenPluginExists ? 2.2 : 1)), 0);

            _xpBar.Rotate(0, 180, 0);
            _xpBar.localEulerAngles = new Vector3(0, 180, 180);
            _xpBar.anchorMax = new Vector2(-0.5f, 0);
            _xpBar.anchorMin = new Vector2(0f, 0f);
            _xpBar.localScale = new Vector3(3.1f, 1, 1);

            _xpBar.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;

            _xpProgressBar = _xpBar.GetChild(1).GetComponent<SpriteRenderer>();
            _xpProgressBar.size = new Vector2(3, 10);
        }
    }
}
