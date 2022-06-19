using EndskApi.Enums.Menus;
using System;
using System.Collections.Generic;
using UnityEngine;
using EndskApi.Information.Menus;
using Il2CppInterop.Runtime.Attributes;

namespace EndskApi.Scripts
{
    public class BaseMenu : MonoBehaviour
    {
        protected static string _currentGeomorph;
        protected static bool _guiInitialized = false;
        protected static GUIStyle _normalStyle;
        protected static GUIStyle _titleStyle;

        protected static readonly float _menuX = 30f;
        protected static readonly float _menuY = Screen.height / 2 - 100f;

        protected MenuStates _currentState;
        protected List<Tool> _tools;

        public BaseMenu(IntPtr intPtr) : base(intPtr)
        {
            _tools = new List<Tool>();
        }

        public string PageTitle { get; set; }
        protected static string PageTitlePostfix { get; set; } = "";

        protected virtual void Update()
        {
            if (_currentState != MenuStates.Deactivated)
            {
                DefaultCheatsInputCheck();
            }
        }

        protected virtual void OnGUI()
        {
            if (_currentState == MenuStates.Active)
            {
                CreateUi(_tools, PageTitle);
            }
        }

        public virtual void SetState(MenuStates newState)
        {
            _currentState = newState;
            if (newState == MenuStates.Deactivated)
            {
                enabled = false;
            }
            else
            {
                enabled = true;
            }
        }

        protected void DefaultCheatsInputCheck()
        {
            foreach (var cheat in _tools)
            {
                if (cheat.CheckInput.CheckKeyDown())
                {
                    cheat.UseTool.Invoke(cheat);
                }
            }
        }

        [HideFromIl2Cpp]
        public static void CreateUi(List<Tool> cheats, string pageTitle)
        {
            if (!_guiInitialized)
            {
                _titleStyle = new GUIStyle(GUI.skin.GetStyle("label")) { fontSize = 22 };
                _normalStyle = new GUIStyle(GUI.skin.GetStyle("label")) { fontSize = 20 };
                _guiInitialized = true;
            }

            GUI.contentColor = Color.white;
            GUI.Label(new Rect(_menuX, _menuY - 25f, 400, 30), _currentGeomorph, _normalStyle);
            GUI.Label(new Rect(_menuX, _menuY, 400, 30), pageTitle + PageTitlePostfix, _titleStyle);

            var yOffset = 25f;
            foreach (var cheat in cheats)
            {
                GUI.Label(new Rect(_menuX, _menuY + (yOffset), 400, 30), cheat.ToString(), _normalStyle);
                yOffset += 22f;
            }
        }

        [HideFromIl2Cpp]
        protected void ToggleTool(Tool cheat)
        {
            cheat.Toggle();
        }
    }
}
