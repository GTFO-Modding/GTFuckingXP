using EndskApi.Enums.Menus;
using EndskApi.Information.Menus;
using EndskApi.Manager;
using EndskApi.Manager.Internal;
using GameData;
using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EndskApi.Scripts
{
    internal class MainMenu : BaseMenu
    {
        private Dictionary<Tool, BaseMenu> _toolToMenuMap;
        private List<IExtendedTool> _middleMouseClickTools = new List<IExtendedTool>();
        private List<IExtendedTool> _timedTools = new List<IExtendedTool>();
        private float _lastToolActive = Time.time;
        private (uint enemyId, string enemyName)[] _enemyNamesIdMap;
        private int _currentEnemyIndex = 0;
        private int _keypadCounter;

        public MainMenu(IntPtr intPtr) : base(intPtr)
        {
            PageTitle = "MainMenu";
            _toolToMenuMap = new Dictionary<Tool, BaseMenu>();

            Instance = this;
        }

        internal static MainMenu Instance { get; private set; }

        /// <summary>
        /// The current index of the EnemyIds array you're spawning right now.
        /// </summary>
        public int CurrentEnemyIndex
        {
            get => _currentEnemyIndex;
            set
            {
                if (value >= _enemyNamesIdMap.Count() || value < 0)
                {
                    value = _currentEnemyIndex;
                }
                _currentEnemyIndex = value;
                PageTitlePostfix = $": {_enemyNamesIdMap[value].enemyName}";
            }
        }

        public void Awake()
        {
            MenuToggleUpdated(new Tool(), false);

            var enemyBlocks = EnemyDataBlock.GetAllBlocks();
            _enemyNamesIdMap = new (uint, string)[enemyBlocks.Count];
            for (int i = 0; i < enemyBlocks.Count; i++)
            {
                _enemyNamesIdMap[i] = (enemyBlocks[i].persistentID, enemyBlocks[i].name);
            }
            CurrentEnemyIndex = 0;
        }

        public void AddPage(string ToolName, BaseMenu menu)
        {
            AddPage(new Tool(ToolName, GetFreeKeypadInput(), false, ToggleTool, MenuToggleUpdated), menu);
        }

        public void AddPage(Tool Tool, BaseMenu menu)
        {
            _toolToMenuMap.Add(Tool, menu);
            _tools.Add(Tool);
        }

        //No need to add this as an api call, because the "ToolExtended" class is kinda internal specific. 
        public void AddMiddleMouseClickTool(IExtendedTool Tool)
        {
            _middleMouseClickTools.Add(Tool);
        }

        public void RemoveMiddleMouseClickTool(IExtendedTool Tool)
        {
            _middleMouseClickTools.Remove(Tool);
        }

        public void AddTimedTool(IExtendedTool Tool)
        {
            _timedTools.Add(Tool);
        }

        public void RemoveTimedTool(IExtendedTool Tool)
        {
            _timedTools.Remove(Tool);
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                if (_currentState == MenuStates.Active || _currentState == MenuStates.HiddenAndActive)
                {
                    _currentState = MenuStates.Deactivated;
                }
                else
                {
                    _currentState = MenuStates.Active;
                }

                foreach (var menu in _toolToMenuMap)
                {
                    menu.Key.CurrentToggleState = false;
                    menu.Value.SetState(MenuStates.Deactivated);
                }
            }

            base.Update();
            MainMenuSpecificUpdate();
        }

        private void MainMenuSpecificUpdate()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) CurrentEnemyIndex++;
            if (Input.GetKeyDown(KeyCode.LeftArrow)) CurrentEnemyIndex--;

            if (Input.GetMouseButtonDown(2))
            {
                foreach (var Tool in _middleMouseClickTools)
                {
                    Tool.ExtraToolAction.Invoke(GetInformationPackage(Tool.InformationId));
                }
            }

            if (_lastToolActive < Time.time)
            {
                foreach (var Tool in _timedTools)
                {
                    Tool.ExtraToolAction.Invoke(GetInformationPackage(Tool.InformationId));
                }

                if (GameStateManager.CurrentStateName == eGameStateName.InLevel)
                {
                    _currentGeomorph = PlayerManager.GetLocalPlayerAgent().CourseNode.m_area.m_geomorph.name;
                }
                else
                {
                    _currentGeomorph = "";
                }

                _lastToolActive = Time.time + 0.25f;
            }
        }

        private object GetInformationPackage(InformationId id)
        {
            switch (id)
            {
                case InformationId.None:
                    return null;
                case InformationId.EnemyId:
                    return _enemyNamesIdMap[CurrentEnemyIndex];
            }

            return null;
        }

        private void MenuToggleUpdated(Tool Tool, bool newToggle)
        {
            foreach (var pair in _toolToMenuMap)
            {
                if (pair.Key.Equals(Tool))
                {
                    pair.Value.SetState(newToggle ? MenuStates.Active : MenuStates.Deactivated);
                    pair.Key.CurrentToggleState = newToggle;
                }
                else
                {
                    pair.Key.CurrentToggleState = false;
                    pair.Value.SetState(MenuStates.Deactivated);
                }
            }

            _currentState = _toolToMenuMap.Any(it => it.Key.CurrentToggleState) ? MenuStates.HiddenAndActive : MenuStates.Active;
        }

        private InputTool GetFreeKeypadInput()
        {
            _keypadCounter += 1;
            switch (_keypadCounter)
            {
                case 1:
                    return MenuInputProvider.KeyPad1;
                case 2:
                    return MenuInputProvider.KeyPad2;
                case 3:
                    return MenuInputProvider.KeyPad3;
                case 4:
                    return MenuInputProvider.KeyPad4;
                case 5:
                    return MenuInputProvider.KeyPad5;
                case 6:
                    return MenuInputProvider.KeyPad6;
                case 7:
                    return MenuInputProvider.KeyPad7;
                case 8:
                    return MenuInputProvider.KeyPad8;
                case 9:
                    return MenuInputProvider.KeyPad9;
            }

            LogManager.Error("There are no free Keypad keys, for the added Menu page!\nPlease ask @Endskill#4992 to finally do his Page system.");
            throw new IndexOutOfRangeException("There are no free keypad keys to add this specific page.");
        }
    }
}
