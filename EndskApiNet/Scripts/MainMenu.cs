using EndskApi.Enums.Menus;
using EndskApi.Information.Menus;
using EndskApi.Manager;
using GameData;
using Il2CppInterop.Runtime.Attributes;
using Player;
using UnityEngine;

namespace EndskApi.Scripts
{
    internal class MainMenu : BaseMenu
    {
        private Dictionary<Tool, BaseMenu> _toolToMenuMap;
        private List<BaseMenu> _unknownMenus;
        private List<IExtendedTool> _middleMouseClickTools = new List<IExtendedTool>();
        private List<IExtendedTool> _timedTools = new List<IExtendedTool>();
        private List<Tool> _hiddenTools = new List<Tool>();
        private float _lastToolActive = Time.time;
        private (uint enemyId, string enemyName)[] _enemyNamesIdMap;
        private int _currentEnemyIndex = 0;
        private int _keypadCounter;

        public MainMenu(IntPtr intPtr) : base(intPtr)
        {
            PageTitle = "MainMenu";
            _toolToMenuMap = new Dictionary<Tool, BaseMenu>();
            _unknownMenus = new List<BaseMenu>();
            _currentState = MenuStates.HiddenAndActive;

            Instance = this;
        }

        [HideFromIl2Cpp]
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
            var enemyBlocks = EnemyDataBlock.GetAllBlocks();
            _enemyNamesIdMap = new (uint, string)[enemyBlocks.Count];
            for (int i = 0; i < enemyBlocks.Count; i++)
            {
                _enemyNamesIdMap[i] = (enemyBlocks[i].persistentID, enemyBlocks[i].name);
            }
            CurrentEnemyIndex = 0;
        }

        [HideFromIl2Cpp]
        public void ActivateUnknownMenu<TScript>(TScript menu) where TScript : BaseMenu
        {
            MenuToggleUpdated(null, false);
            _currentState = MenuStates.HiddenAndActive;
            _unknownMenus.Add(menu);
        }

        [HideFromIl2Cpp]
        public void AddPage(string ToolName, BaseMenu menu)
        {
            AddPage(new Tool(ToolName, GetFreeKeypadInput(), false, ToggleTool, MenuToggleUpdated), menu);
        }

        [HideFromIl2Cpp]
        public void AddPage(Tool Tool, BaseMenu menu)
        {
            _toolToMenuMap.Add(Tool, menu);
            _tools.Add(Tool);
            //if(_toolToMenuMap.Any(it => it.Key.CurrentToggleState))
            //{
                _currentState = MenuStates.Active;
            //}
            //_currentState = _toolToMenuMap.Any(it => it.Key.CurrentToggleState) ? MenuStates.Active : MenuStates.HiddenAndActive;
        }

        [HideFromIl2Cpp]
        public void AddMiddleMouseClickTool(IExtendedTool Tool)
        {
            _middleMouseClickTools.Add(Tool);
        }

        public void RemoveMiddleMouseClickTool(IExtendedTool Tool)
        {
            _middleMouseClickTools.Remove(Tool);
        }

        public void AddTimedTool(IExtendedTool tool)
        {
            _timedTools.Add(tool);
        }

        public void RemoveTimedTool(IExtendedTool tool)
        {
            _timedTools.Remove(tool);
        }

        public void AddHiddenTool(Tool tool)
        {
            _hiddenTools.Add(tool);
            //if()

            //_currentState = _toolToMenuMap.Any(it => it.Key.CurrentToggleState) ? MenuStates.Active : MenuStates.HiddenAndActive;
        }

        public void RemoveHiddenTool(Tool tool)
        {
            _hiddenTools.Remove(tool);
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

            if (_currentState != MenuStates.Deactivated)
            {
                foreach (var hiddenTool in _hiddenTools)
                {
                    if (hiddenTool.CheckInput.CheckKeyDown())
                    {
                        hiddenTool.UseTool.Invoke(hiddenTool);
                    }
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
            foreach(var unknown in _unknownMenus)
            {
                unknown.SetState(MenuStates.Deactivated);
            }

            _unknownMenus.Clear();

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
