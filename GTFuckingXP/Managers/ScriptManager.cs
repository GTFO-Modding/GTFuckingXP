using EndskApi.Api;
using GameData;
using GTFuckingXP.Enums;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using GTFuckingXP.Information.ClassSelector;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Patches;
using GTFuckingXP.Scripts;
using GTFuckingXP.StolenCode;
using Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GTFuckingXP.Managers
{
    public class ScriptManager
    {
        public const string EnemyXpFileName = "EnemyXp.json";
        public const string ExpeditionLvlLayoutMappingFileName = "ExpeditionLvlLayouts.json";
        public const string LevelLayoutFileName = "ClassLayouts.json";
        public const string BoosterLayoutFileName = "BoosterEffects.json";
        public const string GroupFileName = "Groups.json";

        private string _folderPath;
        private bool _initialized = false;
        private bool _versionAllowed;

        public ScriptManager()
        {
            var response = HttpWebRequest.Create(@"https://endskill.github.io/ActiveXpModVersions/ActiveVersions.json");
            response.Credentials = CredentialCache.DefaultCredentials;
            string jsonString;
            using (var streamReader = new StreamReader(response.GetResponse().GetResponseStream()))
            {
                jsonString = streamReader.ReadToEnd();
            }
            var allowedVersion = JsonSerializer.Deserialize<List<string>>(jsonString);

            var currentVersion = Version.Parse(BepInExLoader.VERSION);
            foreach(var versionString in allowedVersion)
            {
                var version = Version.Parse(versionString);
                if(currentVersion == version)
                {
                    _versionAllowed = true;
                    break;
                }
            }

            if(!_versionAllowed)
            {
                LogManager.Error("This version of the xp mod is not recommended to use! Please update immediately.");
                BepInExLoader.Harmony.UnpatchSelf();
            }
        }

        public static ScriptManager Instance { get; set; }

        public bool IsInitialized { get; private set; }

        public void Initialize()
        {
            if (_initialized || !_versionAllowed)
                return;

            _initialized = true;

            //Initializing some static values
            CacheApiWrapper.SetPlayerToLevelMapping(new Dictionary<int, Level>());
           
            CacheApiWrapper.SetDefaultMaxHp(PlayerDataBlock.GetBlock(1).health);
            
            if(MtfoUtils.PluginExists)
            {
                _folderPath = Path.Combine(MtfoUtils.CustomPath, "GtfXP");
            }
            else
            {
                LogManager.Warn("No MTFO was found, using assembly path...");
                _folderPath = Path.Combine(BepInEx.Paths.PluginPath, "XpJson");
            }

            WriteDefaultJsonBlocks();
            UpdateEverything();

            CacheApiWrapper.SetCurrentLevelLayout(CacheApi.GetInstance<List<LevelLayout>>(CacheApiWrapper.XpModCacheName)[0]);

            CheckpointApi.AddCheckpointReachedCallback(CreateCheckpointData);
            CheckpointApi.AddCheckpointCleanupCallback(CheckpointsCleanup);

            if (BepInExLoader.RundownDevMode)
            {
                //CacheApiWrapper.DestroyOldCreateRegisterAndReturnComponent<DevModeTools>();
                //DevToolbelt.Api.DevToolbeltApi.AddPage("Xp Tools", CacheApiWrapper.CreateRegisterAndReturnComponent<DevTools>());
            }
        }

        /// <summary>
        /// Prepares everything to start leveling with 0 xp.
        /// </summary>  
        public void StartLevelScripts()
        {
            if (!_versionAllowed)
                return;

            EnemyDamageBasePatches.DamageDistribution = new Dictionary<string, Dictionary<int, float>>();

            CacheApi.SaveInstance(GuiManager.Current.m_playerLayer.m_playerStatus.gameObject.AddComponent<XpBar>(), CacheApiWrapper.XpModCacheName);
            _ = CacheApiWrapper.DestroyOldCreateRegisterAndReturnComponent<XpHandler>();

            foreach (var callBack in CacheApiWrapper.GetScriptsStartedCallbackList())
            {
                //i don't think, anyone other than the XpExpansion mod will use that functionality, so let's just go quering it each loopitem.
                callBack.Invoke(CacheApiWrapper.GetActiveLevel());
            }

            if (BepInExLoader.RundownDevMode)
            {
                CacheApiWrapper.DestroyOldCreateRegisterAndReturnComponent<DevModeTools>();
            }
        }

        /// <summary>
        /// Kills everything created by this plugin to start again, with no remaining information.
        /// </summary>
        public void EndLevelScripts()
        {
            if (!_versionAllowed)
                return;

            var list = new List<CustomScalingBuff>();
            list.Add(new CustomScalingBuff(CustomScaling.MeleeRangeMultiplier, 1f));
            list.Add(new CustomScalingBuff(CustomScaling.MeleeHitBoxSizeMultiplier, 1f));
            list.Add(new CustomScalingBuff(CustomScaling.MovementSpeedMultiplier, 1f));
            list.Add(new CustomScalingBuff(CustomScaling.AntiFogSphere, 0f));
            list.Add(new CustomScalingBuff(CustomScaling.JumpVelInitialPlus, 0f));
            list.Add(new CustomScalingBuff(CustomScaling.JumpGravityMulDefaultPlus, 0f));
            list.Add(new CustomScalingBuff(CustomScaling.JumpGravityMulButtonReleased, 0f));
            list.Add(new CustomScalingBuff(CustomScaling.JumpGravityMulAfterPeakPlus, 0f));
            list.Add(new CustomScalingBuff(CustomScaling.JumpGravityMulFallingPlus, 0f));
            list.Add(new CustomScalingBuff(CustomScaling.JumpVerticalVelocityMaxPlus, 0f));

            CustomScalingBuffManager.ApplyCustomScalingEffects(PlayerManager.GetLocalPlayerAgent(), list);

            CacheApi.GetInstance<XpBar>(CacheApiWrapper.XpModCacheName).HideTextUi();
            CacheApiWrapper.KillScript<XpHandler>();
            CacheApiWrapper.KillScript<XpBar>();
            CacheApiWrapper.KillScript<DevModeTools>();
            CacheApiWrapper.SetPlayerToLevelMapping(new Dictionary<int, Level>());
            CacheApiWrapper.RemoveDefaultMeleeRange();
            CacheApiWrapper.RemoveDefaultMeleeHitBox();
            EnemyDamageBasePatches.DamageDistribution = null;
        }

        public (List<EnemyXp> enemyXpList, List<LevelLayout> levelLayouts, List<BoosterBuffs> boosterBuffs, List<Group> groups) ReadJsonBlocks()
        {
            var serializerSettings = new JsonSerializerOptions
            {
                IncludeFields = false,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            serializerSettings.Converters.Add(new JsonStringEnumConverter());

            var enemyXpList = JsonSerializer.Deserialize<List<EnemyXp>>(
                File.ReadAllText(Path.Combine(_folderPath, EnemyXpFileName)), serializerSettings);

            if (enemyXpList is null || enemyXpList.Count == 0)
            {
                LogManager.Warn("No Data received for enemies!");
            }

            //var expeditionLevelLayoutMapping = JsonSerializer.Deserialize<List<ExpeditionsLevelMapping>>(
            //    File.ReadAllText(Path.Combine(_folderPath, ExpeditionLvlLayoutMappingFileName)), serializerSettings);

            //if(expeditionLevelLayoutMapping is null || expeditionLevelLayoutMapping.Count == 0)
            //{
            //    LogManager.Warn("No Data received for expeditionMapping!");
            //}

            var levelLayouts = JsonSerializer.Deserialize<List<LevelLayout>>(
                File.ReadAllText(Path.Combine(_folderPath, LevelLayoutFileName)), serializerSettings);

            if (levelLayouts is null || levelLayouts.Count == 0)
            {
                LogManager.Warn("No Data found for XpLayouts/LevelLayouts!");
            }

            var boosterEffects = JsonSerializer.Deserialize<List<BoosterBuffs>>(
               File.ReadAllText(Path.Combine(_folderPath, BoosterLayoutFileName)), serializerSettings);

            if (boosterEffects is null || boosterEffects.Count == 0)
            {
                LogManager.Warn("No Data found for BoosterEffectLayouts!");
            }

            var groups = JsonSerializer.Deserialize<List<Group>>(
                File.ReadAllText(Path.Combine(_folderPath, GroupFileName)), serializerSettings);
            
            if(groups is null || groups.Count == 0)
            {
                LogManager.Warn("Not data found for Groups!");
            }

            return (enemyXpList, levelLayouts, boosterEffects, groups);
        }

        public void UpdateEverything()
        {
            var newData = ReadJsonBlocks();
            
            LogManager.Debug($"Received: {newData.enemyXpList.Count} enemies, {newData.levelLayouts.Count} levelLayouts, {newData.boosterBuffs.Count} BoosterLayouts, {newData.groups.Count} Groups");

            CacheApi.SaveInstance(newData.enemyXpList, CacheApiWrapper.XpModCacheName);
            //_instanceCache.SetInstance(newData.expeditionLevelLayoutMapping);
            CacheApi.SaveInstance(newData.levelLayouts, CacheApiWrapper.XpModCacheName);
            CacheApi.SaveInstance(newData.boosterBuffs, CacheApiWrapper.XpModCacheName);
            CacheApi.SaveInstance(newData.groups, CacheApiWrapper.XpModCacheName);
        }

        public string GetFolderPath()
        {
            return _folderPath;
        }

        private void WriteDefaultJsonBlocks()
        {
            LogManager.Debug("Writing default JsonBlocks...");
            if(!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            var serializerOptions = new JsonSerializerOptions
            {
                IncludeFields = false,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            serializerOptions.Converters.Add(new JsonStringEnumConverter());

            var enemyPath = Path.Combine(_folderPath, EnemyXpFileName);
            if(!File.Exists(enemyPath))
            {
                File.WriteAllText(enemyPath, JsonSerializer.Serialize(DefaultXpData.GetDefaultEnemyXp(), serializerOptions));
            }

            //var expeditionLvlLayoutMappingPath = Path.Combine(_folderPath, ExpeditionLvlLayoutMappingFileName);
            //if(!File.Exists(expeditionLvlLayoutMappingPath))
            //{
            //    File.WriteAllText(expeditionLvlLayoutMappingPath, JsonSerializer.Serialize(DefaultXpData.GetDefaultExpeditionsLevelMapping(), serializerOptions));
            //}

            var levelLayoutsPath = Path.Combine(_folderPath, LevelLayoutFileName);
            if(!File.Exists(levelLayoutsPath))
            {
                File.WriteAllText(levelLayoutsPath, JsonSerializer.Serialize(DefaultXpData.GetDefaultLevelLayout(), serializerOptions));
            }

            var boosterLayoutsPath = Path.Combine(_folderPath, BoosterLayoutFileName);
            if(!File.Exists(boosterLayoutsPath))
            {
                File.WriteAllText(boosterLayoutsPath, JsonSerializer.Serialize(DefaultXpData.GetDefaultBoosterBuffs(), serializerOptions));
            }

            var groupsPath = Path.Combine(_folderPath, GroupFileName);
            if(!File.Exists(groupsPath))
            {
                File.WriteAllText(groupsPath, JsonSerializer.Serialize(DefaultXpData.GetDefaultGroups(), serializerOptions));
            }

            #region EnumValues
            var SingleUseBuffPath = Path.Combine(_folderPath, "LevelUpBonus_EnumNames.txt");
            if (!File.Exists(SingleUseBuffPath))
            {
                var str = new StringBuilder();
                str.AppendLine("--This file is auto-generated. It's not for editing!--");
                str.AppendLine();
                foreach (var mod in Enum.GetValues(typeof(SingleBuff)))
                {
                    str.AppendLine(mod.ToString());
                }
                File.WriteAllText(SingleUseBuffPath, str.ToString());
            }

            var agentModifierPath = Path.Combine(_folderPath, "BoosterEffects_EnumNames.txt");
            if (!File.Exists(agentModifierPath))
            {
                var str = new StringBuilder();
                str.AppendLine("--This file is auto-generated. It's not for editing!--");
                str.AppendLine();
                foreach(var mod in Enum.GetValues(typeof(AgentModifier)))
                {
                    str.AppendLine(mod.ToString());
                }
                File.WriteAllText(agentModifierPath, str.ToString());
            }

            var customScalingPath = Path.Combine(_folderPath, "CustomScaling_EnumNames.txt");
            if (!File.Exists(agentModifierPath))
            {
                var str = new StringBuilder();
                str.AppendLine("--This file is auto-generated. It's not for editing!--");
                str.AppendLine();
                foreach (var mod in Enum.GetValues(typeof(CustomScaling)))
                {
                    str.AppendLine(mod.ToString());
                }
                File.WriteAllText(customScalingPath, str.ToString());
            }
            #endregion
        }

        private void CreateCheckpointData()
        {
            if (CacheApi.TryGetInstance(out XpHandler xpHandler, CacheApiWrapper.XpModCacheName))
            {
                CacheApiWrapper.SetXpStorageData(xpHandler.CurrentTotalXp);
            }
            else
            {
                LogManager.Error("No XpHandler was found, while trying to store the Checkpoint!");
            }
        }

        private void CheckpointsCleanup()
        {
            CacheApi.RemoveInformation(CacheApiWrapper.CheckpointData, CacheApiWrapper.XpModCacheName);
        }
    }
}
