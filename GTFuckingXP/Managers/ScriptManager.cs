﻿using Enemies;
using GameData;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Patches;
using GTFuckingXP.Scripts;
using GTFuckingXP.Scripts.SelectLevelPath;
using GTFuckingXP.StolenCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GTFuckingXP.Managers
{
    public class ScriptManager
    {
        public const string EnemyXpFileName = "EnemyXp.json";
        public const string ExpeditionLvlLayoutMappingFileName = "ExpeditionLvlLayouts.json";
        public const string LevelLayoutFileName = "LevelLayouts.json";

        private readonly InstanceCache _instanceCache;

        private string _folderPath;
        private bool _initialized = false;
        private bool _versionAllowed;

        public ScriptManager()
        {
            _instanceCache = InstanceCache.Instance;

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
                LogManager.Error("This version of the xp mod is not recommended to use! Please update immediately");
            }
        }

        public static ScriptManager Instance { get; set; }

        public void Initialize()
        {
            if (_initialized || !_versionAllowed)
                return;

            _initialized = true;

            _instanceCache.SetDefaultMaxHp(PlayerDataBlock.GetBlock(1).health);
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
        }

        /// <summary>
        /// Prepares everything to start leveling with 0 xp.
        /// </summary>  
        public void StartLevelScripts()
        {
            if (!_versionAllowed)
                return;

            EnemyDamageBasePatches.DamageDistribution = new Dictionary<string, Dictionary<int, float>>();

            _instanceCache.SetInstance(GuiManager.Current.m_playerLayer.m_playerStatus.gameObject.AddComponent<XpBar>());
            _ = _instanceCache.DestroyOldCreateRegisterAndReturnComponent<XpHandler>();
            InstanceCache.Instance.KillScript<SelectLevelPathHandler>();
            if (BepInExLoader.RundownDevMode.Value)
            {
                _instanceCache.DestroyOldCreateRegisterAndReturnComponent<DevModeTools>();
            }
        }

        /// <summary>
        /// Kills everything created by this plugin to start again, with no remaining information.
        /// </summary>
        public void EndLevelScripts()
        {
            if (!_versionAllowed)
                return;
            _instanceCache.KillScript<XpHandler>();
            _instanceCache.KillScript<XpBar>();
            _instanceCache.KillScript<DevModeTools>();
            _instanceCache.SetPlayerToLevelMapping(new Dictionary<int, int>());
            EnemyDamageBasePatches.DamageDistribution = null;
        }

        public (List<EnemyXp> enemyXpList, List<LevelLayout> levelLayouts) ReadJsonBlocks()
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
            
            if(enemyXpList is null || enemyXpList.Count == 0)
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

            if(levelLayouts is null || levelLayouts.Count == 0)
            {
                LogManager.Warn("No Data received for XpLayouts/LevelLayouts!");
            }
            
            return (enemyXpList, levelLayouts);
        }

        public void UpdateEverything()
        {
            var newData = ReadJsonBlocks();
            
            LogManager.Debug($"Received: {newData.enemyXpList.Count} enemies, {newData.levelLayouts.Count} levelLayouts");

            _instanceCache.SetInstance(newData.enemyXpList);
            //_instanceCache.SetInstance(newData.expeditionLevelLayoutMapping);
            _instanceCache.SetInstance(newData.levelLayouts);

            //var currentMission = RundownManager.GetActiveExpeditionData();
            //LogManager.Debug($"current mission data is: Tier={currentMission.tier}, ExpeditionIndex={currentMission.expeditionIndex}");

            //foreach(var mapObj in newData.expeditionLevelLayoutMapping)
            //{
            //    LogManager.Debug($"ReadData contains file with: Tier={mapObj.Tier}, ExpeditionsIndex={mapObj.ExpeditionIndex}");
            //}

            //_instanceCache.SetCurrentLevelLayout(newData.levelLayouts.FirstOrDefault(it => it.Id == newData.expeditionLevelLayoutMapping.First(x =>
            //  x.Tier == currentMission.tier && x.ExpeditionIndex == currentMission.expeditionIndex).LevelLayoutId));
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
        }
    }
}
