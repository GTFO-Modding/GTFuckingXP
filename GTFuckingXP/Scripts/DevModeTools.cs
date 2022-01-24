using EndskApi.Api;
using GTFuckingXP.Communication;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GTFuckingXP.Scripts
{
    /// <summary>
    /// A menu that can be hidden to 
    /// </summary>
    public class DevModeTools : MonoBehaviour
    {
        private static bool _guiInitialized = false;
        private static GUIStyle _normalStyle;

        private readonly float _xPos = 30f;
        private readonly float _yPos = Screen.height / 2 - 300f;

        private bool _active = true;
        private string _addXpNumber;
        private float _timeTillXpNumberInvalid;

        public DevModeTools(IntPtr intPtr) : base(intPtr)
        {
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Delete))
            {
                _active = !_active;
            }

            if(!_active)
            {
                return;
            }

            if(Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                if(XpApi.SetCurrentLevel(CacheApiWrapper.GetActiveLevel().LevelNumber + 1, out var cheatedXp))
                {
                    CheatedXpMessage(cheatedXp);
                }
            }

            if(Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                if (XpApi.SetCurrentLevel(CacheApiWrapper.GetActiveLevel().LevelNumber -1, out var cheatedXp))
                {
                    CheatedXpMessage(cheatedXp);
                }
            }

            if(Input.GetKeyDown(KeyCode.KeypadMultiply))
            {
                XpApi.ReloadData();
            }

            if(Input.GetKeyDown(KeyCode.KeypadDivide))
            {
                var levelLayouts = CacheApi.GetInstance<List<LevelLayout>>();
                var currentLayout = CacheApiWrapper.GetCurrentLevelLayout();

                var index = levelLayouts.IndexOf(currentLayout);
                if(levelLayouts.Count <= index + 1)
                {
                    XpApi.ChangeCurrentLevelLayout(levelLayouts[0]);
                }
                else
                {
                    XpApi.ChangeCurrentLevelLayout(levelLayouts[index + 1]);
                }
            }

            if (Input.GetKeyDown(KeyCode.Keypad0))
                AddCharToXpNumber("0");
            if (Input.GetKeyDown(KeyCode.Keypad1))
                AddCharToXpNumber("1");
            if (Input.GetKeyDown(KeyCode.Keypad2))
                AddCharToXpNumber("2");
            if (Input.GetKeyDown(KeyCode.Keypad3))
                AddCharToXpNumber("3");
            if (Input.GetKeyDown(KeyCode.Keypad4))
                AddCharToXpNumber("4");
            if (Input.GetKeyDown(KeyCode.Keypad5))
                AddCharToXpNumber("5");
            if (Input.GetKeyDown(KeyCode.Keypad6))
                AddCharToXpNumber("6");
            if (Input.GetKeyDown(KeyCode.Keypad7))
                AddCharToXpNumber("7");
            if (Input.GetKeyDown(KeyCode.Keypad8))
                AddCharToXpNumber("8");
            if (Input.GetKeyDown(KeyCode.Keypad9))
                AddCharToXpNumber("9");

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (!string.IsNullOrEmpty(_addXpNumber))
                {
                    XpApi.AddXp(Convert.ToUInt32(_addXpNumber));
                    PlayerChatManager.WantToSentTextMessage(PlayerManager.GetLocalPlayerAgent(), $"Cheated {_addXpNumber}XP");
                }
            }
        }

        public void OnGUI()
        {
            if(!_active)
            {
                return;
            }

            if (!_guiInitialized)
            {
                _normalStyle = new GUIStyle(GUI.skin.GetStyle("label")) { fontSize = 22 };
                _guiInitialized = true;
            }

            GUI.contentColor = Color.white;
            GUI.Label(new Rect(_xPos, _yPos, 400, 30), $"Xp dev tools:", _normalStyle);
            GUI.Label(new Rect(_xPos, _yPos + 25f, 400, 30), $"Reload xp data : Keypad*", _normalStyle);
            GUI.Label(new Rect(_xPos, _yPos + 50f, 400, 30), $"Change class : Keypad/", _normalStyle);
            GUI.Label(new Rect(_xPos, _yPos + 75f, 400, 30), $"Level up : Keypad+", _normalStyle);
            GUI.Label(new Rect(_xPos, _yPos + 100f, 400, 30), $"Level down : Keypad-", _normalStyle);
            GUI.Label(new Rect(_xPos, _yPos + 125f, 400, 30), $"AddXP \"{_addXpNumber}\" KeypadEnter to add XP", _normalStyle);
        }

        private void AddCharToXpNumber(string number)
        {
            if(Time.time > _timeTillXpNumberInvalid)
            {
                _addXpNumber = string.Empty;
            }

            _addXpNumber += number;
            _timeTillXpNumberInvalid = Time.time + 2f;
        }

        private void CheatedXpMessage(float xpAmount)
        {
            PlayerChatManager.WantToSentTextMessage(PlayerManager.GetLocalPlayerAgent(), $"Cheated {xpAmount}XP");
        }
    }
}
