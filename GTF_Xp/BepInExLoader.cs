using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using BepInEx.Unity.IL2CPP;
using EndskApi.Api;
using GTFuckingXp.Patches;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using GTFuckingXP.Patches;
using GTFuckingXP.Patches.SelectLevelPatches;
using GTFuckingXP.Scripts;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;

namespace GTFuckingXP
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency("dev.gtfomodding.gtfo-api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("Endskill.EndskApi", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.dak.FloatingTextAPI", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(ESCWrapper.PLUGIN_GUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(CCWrapper.PLUGIN_GUID, BepInDependency.DependencyFlags.SoftDependency)]
    public class BepInExLoader : BasePlugin
    {
        public const string
        MODNAME = "GTFuckingXP",
        AUTHOR = "Endskill",
        GUID = AUTHOR + "." + MODNAME,
        VERSION = "2.3.3";

        public static bool RundownDevMode { get; private set; }
        public static ConfigEntry<bool> DebugMessages { get; private set; }
        public static ConfigEntry<bool> LvlUpPopups { get; private set; }
        public static ConfigEntry<bool> XpPopups { get; private set; }
        public static ConfigEntry<string> TermsOfUsage { get; internal set; }
        public static ConfigEntry<bool> ShowPlayerLevels { get; private set; }
        public static ConfigEntry<string> LevelColor { get; internal set; }
        public static TermsOfUsage TermsOfUsageState { get; private set; }
        public static Harmony Harmony { get; private set; }

        public override void Load()
        {
            RundownDevMode = Config.Bind("Dev Settings", "RundownDev Mode", false, "This will activate the xp dev tool while in an expedition \nPress \"Delete\" to hide/show it").Value;
            DebugMessages = Config.Bind("Dev Settings", "DebugMessages", false, "This settings activates/deactivates debug messages in the console for this specific plugin.");
            
            LvlUpPopups = Config.Bind("Popups", "Lvl up popups", true, "If Lvl UP popups should be shown.");
            XpPopups = Config.Bind("Popups", "XP gain popups", true, "If XP gain popups should be shown");

            ShowPlayerLevels = Config.Bind("Player Level Text", "Show Player Levels", true, "If levels should be shown above other players' names.");
            LevelColor = Config.Bind("Player Level Text", "Level Text Color", "F80", "The color used for player levels.");

            //TODO remove
            TermsOfUsageState = Information.TermsOfUsage.Declined;
            //TODO uncomment
            //TermsOfUsage = Config.Bind("Terms of Usage", "Accept", "Undecided", "This tells the plugin, if you want to save xp collection data of any played expedition with the XP mod.\n" +
            //    "This includes following information: SteamId, PlayFabId, and then you send a package of collected xp every 5 minutes in any modded run.\n" +
            //    "Accepted Values: \"Undecided\", \n" +
            //    "\"Accepted\" : Send packages containing all information, this will allow you to see.\n" +
            //    "\"Declined\" : Send absolutely no packages, you won't be capable of seeing any general xp data later.\n" +
            //    "\"Anonymized\" : Send packages but with no way, to track down the steam account you have played with. This way your data still counts towards xp average for any expedition.");
            //UpdateTermsOfUsage();
            //if (TermsOfUsageState == Information.TermsOfUsage.Undecided)
            //{
            //    TermsOfUsage.SettingChanged += TermsOfUsageChanged;
            //}

            ClassInjector.RegisterTypeInIl2Cpp<XpHandler>();
            ClassInjector.RegisterTypeInIl2Cpp<XpBar>();
            ClassInjector.RegisterTypeInIl2Cpp<DevModeTools>();

            ClassInjector.RegisterTypeInIl2Cpp<DevTools>();

            ScriptManager.Instance = new ScriptManager();
            BoosterBuffManager.Instance = new BoosterBuffManager();

            NetworkApiXpManager.Setup();
            ESCWrapper.Init();

            Harmony = new Harmony(GUID);
            FasterPatching();

            CacheApiWrapper.SetLvlUpCallBackList(new List<Action<Level>>());
            CacheApiWrapper.SetScriptsStartedCallBackList(new List<Action<Level>>());
            InitApi.AddInitCallback(() => { ScriptManager.Instance.Initialize(); });

            //if (IL2CPPChainloader.Instance.Plugins.ContainsKey("Endskill.DevToolbelt"))
            //{
            //    RundownDevMode = true;
            //    ClassInjector.RegisterTypeInIl2Cpp<DevTools>();
            //}
        }

        private void FasterPatching()
        {
            //LevelSelectorPatches
            Harmony.PatchAll(typeof(PlayerLobbyBarPatches));

            //General xp mod usage
            Harmony.PatchAll(typeof(GS_InLevelPatches));
            Harmony.PatchAll(typeof(EnemyDamageLimbPatches));
            Harmony.PatchAll(typeof(PlayerDamagePatches));
            Harmony.PatchAll(typeof(SentryGunCheckPatches));
            Harmony.PatchAll(typeof(SentryGunFiringPatches));
            Harmony.PatchAll(typeof(GS_AfterLevelPatches));
            if (ShowPlayerLevels.Value)
                Harmony.PatchAll(typeof(PlaceNavMarkerOnGoPatches));
            Harmony.PatchAll(typeof(SnetSessionHubPatches));
            if (!CCWrapper.HasCC) // CConsole native patches the function we need, can't patch if it exists
                Harmony.PatchAll(typeof(PlayerRegenPatches));
        }

        private void TermsOfUsageChanged(object sender, EventArgs e)
        {
            LogManager.Debug($"Accepting terms of usage while ingame.");
            UpdateTermsOfUsage();
            TermsOfUsage.SettingChanged -= TermsOfUsageChanged;
        }

        private void UpdateTermsOfUsage()
        {
            System.Enum.TryParse<TermsOfUsage>(TermsOfUsage.Value, out var enumValue);
            TermsOfUsageState = enumValue;
        }
    }
}
