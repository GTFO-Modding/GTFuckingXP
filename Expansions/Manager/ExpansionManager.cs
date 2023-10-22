using EndskApi.Api;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using XpExpansions.Extensions;
using XpExpansions.Information;

namespace XpExpansions.Manager
{
    public class ExpansionManager : BaseManager
    {
        public const string ExpansionActivePath = "ExpansionsActive.json";

        public ExpansionManager()
        {
            LogManager.Message("ExpansionManager constructor.");

            InitApi.AddInitCallback(Initialize);
            LevelApi.AddEndLevelCallback(LevelCleanup);
            GTFuckingXP.Communication.XpApi.AddOnLevelUpCallback(LevelReached);
            GTFuckingXP.Communication.XpApi.AddScriptsLoaded(LevelInitialized);
        }

        public override void Initialize()
        {
            CacheApiWrapper.SetFolderPath(Path.Combine(ScriptManager.Instance.GetFolderPath(), "Expansions"));

            WriteDefaultData();
            var managers = CreateManagers();

            CacheApi.SaveInstance(managers, CacheApiWrapper.ExtensionCacheName);

            foreach(var manager in managers)
            {
                manager.Initialize();
            }
        }

        public override void LevelCleanup()
        {
            var managers = CacheApi.GetInstance<List<BaseManager>>(CacheApiWrapper.ExtensionCacheName);
            foreach (var manager in managers)
            {
                manager.LevelCleanup();
            }
        }

        public override void LevelReached(Level level)
        {
            LogManager.Message("LevelReached in the Expansion Manager.");

            var managers = CacheApi.GetInstance<List<BaseManager>>(CacheApiWrapper.ExtensionCacheName);
            foreach (var manager in managers)
            {
                manager.LevelReached(level);
            }
        }

        public override void LevelInitialized(Level level)
        {
            LogManager.Message("LevelInitialized in the Expansion Manager.");

            var managers = CacheApi.GetInstance<List<BaseManager>>(CacheApiWrapper.ExtensionCacheName);
            foreach (var manager in managers)
            {
                manager.LevelInitialized(level);
            }
        }

        private List<BaseManager> CreateManagers()
        {
            var managers = new List<BaseManager>();

            var expansionsPath = Path.Combine(FolderPath, ExpansionActivePath);
            var activeExpansions = JsonSerializer.Deserialize<ActiveExpansions>(File.ReadAllText(expansionsPath));

            LogManager.Debug("CreateManagers method.");

            if(activeExpansions != null)
            {
                if(activeExpansions.DoubleJumpAbility)
                {
                    managers.Add(new DoubleJumpManager());
                }

                //if(activeExpansions.ExplosionAbility)
                //{
                //    managers.Add(new ExplosionAbilityManager());
                //}

                if(activeExpansions.StartingXp)
                {
                    managers.Add(new StartingLevelXpManager());
                }

                if(activeExpansions.LivingBioAbility)
                {
                    managers.Add(new ClientSidedBioTrackerManager());
                }
            }

            return managers;
        }

        private void WriteDefaultData()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            var activeExpansionsPath = Path.Combine(FolderPath, ExpansionActivePath);
            if(!File.Exists(activeExpansionsPath))
            {
                File.WriteAllText(activeExpansionsPath, JsonSerializer.Serialize(new ActiveExpansions(false, true)));
            }
        }
    }
}
