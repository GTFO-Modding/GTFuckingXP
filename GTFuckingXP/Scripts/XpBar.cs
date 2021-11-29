using BepInEx.IL2CPP;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// XPBar Ui Element.
    /// </summary>
    public class XpBar : MonoBehaviour
    {
        //private bool _initialized = false;

        //private TextMeshPro _xpText;
        private RectTransform _xpBar;
        private SpriteRenderer _xpProgressBar;

        //private DateTime _dateTime;

        public XpBar(IntPtr intPtr) : base(intPtr)
        {
            //_dateTime = DateTime.Now.AddSeconds(1);

            bool oxygenPluginExists = false;
            if (IL2CPPChainloader.Instance.Plugins.TryGetValue("com.chasetug.Oxygen", out var info))
            {
                oxygenPluginExists = true;
            }

            var playerstatus = GuiManager.Current.m_playerLayer.m_playerStatus;

            //_xpText = playerstatus.m_healthText.gameObject.Instantiate<TextMeshPro>("AirText");
            //_xpText.m_max_characters = 1000;
            //_xpText.m_max_numberOfLines = 1000;

            //_xpText.SetText("XPREEEEEEEE");
            //_xpText.ForceMeshUpdate();


            XpBarStuff();
        }

        public Vector3 XpBarLocalPosition => _xpBar.localPosition;

        //public void Update()
        //{
        //    if (_initialized)
        //        return;

        //    if(_dateTime < DateTime.Now)
        //    {
        //        _xpText.transform.localPosition = _xpBar.transform.localPosition;
        //        _xpText.transform.Translate(new Vector3(140f, 80f, 0));
        //        _xpText.alignment = TextAlignmentOptions.BottomLeft;
                
        //        //var rectTransform = _xpText.m_renderer.transform.Cast<RectTransform>();

        //        //rectTransform.offsetMax = Vector2.zero;
        //        //rectTransform.offsetMin = Vector2.zero;

        //        //rectTransform.anchorMax = new Vector2(-0.25f, 0);
        //        //rectTransform.anchorMin = Vector2.zero;

        //        //rectTransform.anchoredPosition = Vector2.zero;
        //        //rectTransform.anchoredPosition3D = Vector2.zero;
        //    }
        //}

        public void XpBarStuff()
        {
            if(_xpBar != null)
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
