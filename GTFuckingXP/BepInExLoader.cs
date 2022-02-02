using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using EndskApi.Api;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using GTFuckingXP.Patches;
using GTFuckingXP.Patches.SelectLevelPatches;
using GTFuckingXP.Scripts;
using GTFuckingXP.Scripts.SelectLevelPath;
using HarmonyLib;
using System;
using System.Collections.Generic;
using UnhollowerRuntimeLib;

namespace GTFuckingXP
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency("dev.gtfomodding.gtfo-api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("Endskill.EndskApi", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.dak.FloatingTextAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class BepInExLoader : BasePlugin
    {
        public const string
        MODNAME = "GTFuckingXP",
        AUTHOR = "Endskill",
        GUID = AUTHOR + "." + MODNAME,
        VERSION = "1.3.0";

        public static ConfigEntry<bool> RundownDevMode { get; private set; }
        public static ConfigEntry<bool> DebugMessages { get; private set; }
        public static ConfigEntry<bool> DamagePopups { get; private set; }
        public static ConfigEntry<bool> LvlUpPopups { get; private set; }
        public static ConfigEntry<bool> XpPopups { get; private set; }
        public static ConfigEntry<string> TermsOfUsage { get; internal set; }
        public static TermsOfUsage TermsOfUsageState { get; private set; }
        public static Harmony Harmony { get; private set; }

        public override void Load()
        {
            RundownDevMode = Config.Bind("Dev Settings", "RundownDev Mode", false, "This will activate the xp dev tool while in an expedition \nPress \"Delete\" to hide/show it");
            DebugMessages = Config.Bind("Dev Settings", "DebugMessages", false, "This settings activates/deactivates debug messages in the console for this specific plugin.");
            
            DamagePopups = Config.Bind("Popups", "Damanage popup", true, "If damage numbers should be shown.");
            LvlUpPopups = Config.Bind("Popups", "Lvl up popups", true, "If Lvl UP popups should be shown.");
            XpPopups = Config.Bind("Popups", "XP gain popups", true, "If XP gain popups should be shown");


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
            ClassInjector.RegisterTypeInIl2Cpp<SelectLevelPathHandler>();
            if (RundownDevMode.Value)
            {
                ClassInjector.RegisterTypeInIl2Cpp<DevModeTools>();
            }

            ScriptManager.Instance = new ScriptManager();
            BoosterBuffManager.Instance = new BoosterBuffManager();

            NetworkApiXpManager.Setup();

            Harmony = new Harmony(GUID);
            FasterPatching();

            CacheApiWrapper.SetLvlUpCallBackList(new List<Action<Level>>());
            InitApi.AddInitCallback(() => { ScriptManager.Instance.Initialize(); });
        }

        private void FasterPatching()
        {
            //LevelSelectorPatches
            Harmony.PatchAll(typeof(MainMenuGuiLayerPatches));
            Harmony.PatchAll(typeof(PlayerLobbyBarPatches));

            //General xp mod usage
            Harmony.PatchAll(typeof(EnemyDamageBasePatches));
            Harmony.PatchAll(typeof(GS_InLevelPatches));
            Harmony.PatchAll(typeof(GS_AfterLevelPatches));
            Harmony.PatchAll(typeof(PlaceNavMarkerOnGoPatches));
            Harmony.PatchAll(typeof(SnetSessionHubPatches));
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
