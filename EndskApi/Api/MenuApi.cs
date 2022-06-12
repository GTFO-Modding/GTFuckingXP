using EndskApi.Information.Menus;
using EndskApi.Scripts;
using UnityEngine;

namespace EndskApi.Api
{
    public static class MenuApi
    {
        static MenuApi()
        {
            //TODO GameObject erstellen.
            var gameObj = new GameObject("EndskApi_Menu");
            CacheApi.SaveInstance(gameObj.AddComponent<MainMenu>(), CacheApi.InternalCache);
            UnityEngine.Object.DontDestroyOnLoad(gameObj);
        }

        /// <summary>
        /// Activates an unknown menu in the MainMenu. The added Menu will get removed when opening any other menu again.
        /// </summary>
        public static void ActivateUnknownMenu<TScript>(TScript menu) where TScript : BaseMenu
        {
            CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache).ActivateUnknownMenu(menu);
        }

        public static TScript AddMenu<TScript>(string pageName) where TScript : BaseMenu
        {
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            var script = mainMenu.gameObject.AddComponent<TScript>();

            mainMenu.AddPage(pageName, script);

            CacheApi.SaveInstance(script, CacheApi.InternalCache);
            return script;
        }

        public static TScript GetMenu<TScript>() where TScript : BaseMenu
        {
            return CacheApi.GetInstance<TScript>(CacheApi.InternalCache);
        }

        public static void AddMiddleMouseClickTool(IExtendedTool tool)
        {
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.AddMiddleMouseClickTool(tool);
        }

        public static void RemoveMiddleMouseClickTool(IExtendedTool tool)
        {
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.RemoveMiddleMouseClickTool(tool);
        }

        public static void AddTimerTool(IExtendedTool tool)
        {
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.AddTimedTool(tool);
        }

        public static void RemoveTimerTool(IExtendedTool tool)
        {
            var mainMenu = CacheApi.GetInstance<MainMenu>(CacheApi.InternalCache);
            mainMenu.RemoveTimedTool(tool);
        }
    }
}
