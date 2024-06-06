using EndskApi.Information.Menus;
using EndskApi.Scripts;
using UnityEngine;

namespace EndskApi.Api
{
    public static class MenuApi
    {
        private static bool _setup = false;
        static MenuApi()
        {
            //TODO GameObject erstellen.

        }

        internal static void Setup()
        {
            if (!_setup)
            {
                var gameObj = new GameObject("EndskApi_Menu");
                CacheApi.SaveInstance(gameObj.AddComponent<MainMenu>(), CacheApi.InternalCache);
                UnityEngine.Object.DontDestroyOnLoad(gameObj);
                _setup = true;
            }
        }

        /// <summary>
        /// Activates an unknown menu in the MainMenu. The added Menu will get removed when opening any other menu again.
        /// </summary>
        public static void ActivateUnknownMenu<TScript>(TScript menu) where TScript : BaseMenu
        {
            Setup();
            CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache).ActivateUnknownMenu(menu);
        }

        public static TScript AddMenu<TScript>(string pageName) where TScript : BaseMenu
        {
            Setup();
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            var script = mainMenu.gameObject.AddComponent<TScript>();

            mainMenu.AddPage(pageName, script);

            CacheApi.SaveInstance(script, CacheApi.InternalCache);
            return script;
        }

        public static TScript GetMenu<TScript>() where TScript : BaseMenu
        {
            Setup();
            return CacheApi.GetInstance<TScript>(CacheApi.InternalCache);
        }

        public static void AddMiddleMouseClickTool(IExtendedTool tool)
        {
            Setup();
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.AddMiddleMouseClickTool(tool);
        }

        public static void RemoveMiddleMouseClickTool(IExtendedTool tool)
        {
            Setup();
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.RemoveMiddleMouseClickTool(tool);
        }

        public static void AddTimerTool(IExtendedTool tool)
        {
            Setup();
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.AddTimedTool(tool);
        }

        public static void RemoveTimerTool(IExtendedTool tool)
        {
            Setup();
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.RemoveTimedTool(tool);
        }

        public static void AddHiddenFunction(Tool tool)
        {
            Setup();
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.AddHiddenTool(tool);
        }

        public static void RemoveHiddenFunction(Tool tool)
        {
            Setup();
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.RemoveHiddenTool(tool);
        }
    }
}
