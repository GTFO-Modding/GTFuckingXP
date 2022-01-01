﻿using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GTFuckingXP.Scripts.SelectLevelPath
{
    /// <summary>
    /// Temporary solution for selecting a level in the loadout menu.
    /// </summary>
    public class SelectLevelPathHandler : MonoBehaviour
    {
        private static readonly float _xPos = Screen.width / 3;
        private static readonly float _yPos = Screen.height / 6;

        private static bool _guiInitialized = false;
        private static GUIStyle _normalStyle;

        private readonly InstanceCache _instanceCache;
        protected static GUIStyle _windowHeaderStyle;

        private int _currentIndex = 0;

        public SelectLevelPathHandler(IntPtr intPtr) : base(intPtr)
        {
            _instanceCache = InstanceCache.Instance;
        }

        public List<LevelLayout> LevelLayoutsSelectable { get; private set; }
        public int CurrentIndex
        {
            get => _currentIndex;
            private set
            {
                if (value >= LevelLayoutsSelectable.Count())
                {
                    value = 0;
                }
                if(value < 0)
                {
                    value = LevelLayoutsSelectable.Count() - 1;
                }

                _currentIndex = value;
                _instanceCache.SetCurrentLevelLayout(LevelLayoutsSelectable[value]);
            }
        }
        public void Awake()
        {
            LevelLayoutsSelectable = _instanceCache.GetInstance<List<LevelLayout>>();
            CurrentIndex = 0;
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                CurrentIndex++;
            }

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                CurrentIndex--;
            }
        }

        public void OnGUI()
        {
            if(!_guiInitialized)
            {
                _normalStyle = new GUIStyle(GUI.skin.GetStyle("label")) { fontSize = 25 };
                _guiInitialized = true;
            }

            for(int index = 0; index < LevelLayoutsSelectable.Count(); index++)
            {
                if(index == CurrentIndex)
                {
                    GUI.contentColor = Color.red;
                }
                else
                {
                    GUI.contentColor = Color.gray;
                }

                var level = LevelLayoutsSelectable[index];
                GUI.Label(new Rect(_xPos, _yPos + (index * 24), 200, 30), $"{level.Header}",
                    _normalStyle);
            }

            GUI.contentColor = Color.white;
            GUI.Label(new Rect(_xPos + 200f, _yPos, 600, 24 * LevelLayoutsSelectable.Count()), 
                LevelLayoutsSelectable[CurrentIndex].InfoText, _normalStyle);
        }
    }
}